<?php
namespace NikeStore\Models;

class EditorModel extends BaseModel
{
    /**
     * @GET
     * @param $username
     * @param $password
     * @return bool
     */
    public function login($username, $password)
    {
        $stmt = self::$db->prepare("SELECT username, password FROM editors Where username = ?");
        $stmt->bind_param("s", $username);
        $stmt->execute();
        $result = $stmt->get_result()->fetch_assoc();

        if($password == $result['password']) {
            return true;
        }
        return false;
    }

    /**
     * @GET
     * @return mixed
     */
    public function getCategories()
    {
        $stmt = self::$db->query("SELECT id, categoryName FROM categories");
        return $stmt->fetch_all(MYSQLI_ASSOC);
    }

    /**
     * @POST
     * @param $category
     * @return bool
     */
    public function addCategories($category)
    {
        $stmt = self::$db->prepare(" INSERT INTO categories (categoryName) VALUES(?)");
        $stmt->bind_param("s", $category);
        $stmt->execute();
        return $stmt->affected_rows > 0;
    }

    /**
     * @DELETE
     * @param $id
     * @return bool
     */
    public function deleteCategory($id)
    {
        $statement = self::$db->prepare(" DELETE FROM categories WHERE id = ?");
        $statement->bind_param("i", $id);
        $statement->execute();
        return $statement->affected_rows > 0;
    }


    /**
     * @GET
     * @return mixed
     */
    public function getShoes()
    {
        $stmt = self::$db->query("SELECT id, name, price, quantity, product FROM shoes");
        return $stmt->fetch_all(MYSQLI_ASSOC);
    }

    /**
     * @GET
     * @return mixed
     */
    public function getShirts()
    {
        $stmt = self::$db->query("SELECT id, name, price, quantity, product FROM shirts");
        return $stmt->fetch_all(MYSQLI_ASSOC);
    }
    /**
     * @GET
     * @param $product
     * @param $id
     * @return array
     */
    public function find($product, $id)
    {
        $statement = self::$db->prepare(
            "SELECT id, quantity FROM $product WHERE id = ?");
        $statement->bind_param("i", $id);
        $statement->execute();
        return $statement->get_result()->fetch_assoc();
    }

    /**
     * @POST
     * @param $name
     * @param $price
     * @param $quantity
     * @param $product
     * @param $categoryId
     * @param $promotion
     * @return bool
     */
    public function addProducts($name, $price, $quantity, $product, $categoryId, $promotion)
    {
        if (empty($name) || $price < 0
            || $quantity < 0 || empty($product)
            || empty($categoryId)) {
            return false;
        }
        $date = date("Y-m-d");
        $stmt = self::$db->prepare
        (" INSERT INTO $product (name, price, quantity, categoryId, createdOn, promotion) VALUES(?, ?, ?, ?, ?, ?)");
        $stmt->bind_param("sdissi", $name, $price, $quantity, $categoryId, $date, $promotion);
        $stmt->execute();
        return $stmt->affected_rows > 0;

    }

    /**
     * @POST
     * @param $id
     * @param $quantity
     * @param $categoryId
     * @param $product
     * @return bool
     */
    public function editProduct($id, $product, $quantity, $categoryId)
    {
        if ($quantity < 0) {
            return false;
        }
        $statement = self::$db->prepare(
            "UPDATE $product SET quantity = ?, categoryId = ? WHERE id = ?");
        $statement->bind_param("iii", $quantity, $categoryId,  $id);
        $statement->execute();
        return $statement->errno == 0;
    }

    /**
     * @DELETE
     * @param $product
     * @param $id
     * @return bool
     */
    public function deleteProduct($product, $id)
    {
        $statement = self::$db->prepare("DELETE FROM $product WHERE id = ?");
        $statement->bind_param("i", $id);
        $statement->execute();
        return $statement->affected_rows > 0;
    }

    public function reorder($orderShoes, $orderShirts)
    {
        $shoes = self::$db->prepare("UPDATE shoes SET orderby = ?");
        $shoes->bind_param("s", $orderShoes);
        $shoes->execute();
        $result = $shoes->affected_rows > 0;

        if(!$result){
            return false;
        }

        $shirts = self::$db->prepare("UPDATE shirts SET orderby = ?");
        $shirts->bind_param("s", $orderShirts);
        $shirts->execute();
        $result = $shirts->affected_rows > 0;

        if(!$result){
            return false;
        }

        return true;
    }
}