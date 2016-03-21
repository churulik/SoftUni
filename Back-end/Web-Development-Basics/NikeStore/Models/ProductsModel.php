<?php
namespace NikeStore\Models;

class ProductsModel extends BaseModel
{
    /**
     * @GET
     * @return mixed
     */
    public function getAllShoes()
    {
        $ownerId = $_SESSION['id'];
        $stmt = self::$db->query("SELECT s.id, s.name, c.categoryName, s.price, s.quantity, s.promotion, s.product
                                    FROM shoes s, categories c
                                    WHERE s.categoryId = c.Id
                                    AND ownerId = $ownerId
                                    ORDER BY s.id");

        return $stmt->fetch_all(MYSQLI_ASSOC);
    }

    /**
     * @GET
     * @return mixed
     */
    public function getAllShirts()
    {
        $ownerId = $_SESSION['id'];
        $stmt = self::$db->query("SELECT s.id, s.name, c.categoryName, s.price, s.quantity, s.promotion, s.product
                                    FROM shirts s, categories c
                                    WHERE s.categoryId = c.Id
                                    AND ownerId = $ownerId
                                    ORDER BY s.id");
        return $stmt->fetch_all(MYSQLI_ASSOC);
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
    public function add($name, $price, $quantity, $product, $categoryId, $promotion)
    {
        if (empty($name) || $price < 0
            || $quantity < 0 || empty($product)
            || empty($categoryId)) {
            return false;
        }
        $date = date("Y-m-d");
        $stmt = self::$db->prepare
        (" INSERT INTO $product (name, product, price, quantity, categoryId, createdOn, ownerId, promotion) VALUES(?, ?, ?, ?, ?, ?, ?, ?)");
        $stmt->bind_param("ssdissii", $name, $product, $price, $quantity, $categoryId, $date, $_SESSION['id'], $promotion);
        $stmt->execute();
        return $stmt->affected_rows > 0;
    }

    public function getCategories()
    {
        $stmt = self::$db->query("SELECT id, categoryName FROM categories");
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
            "SELECT id, name, price, quantity, product FROM $product WHERE id = ?");
        $statement->bind_param("i", $id);
        $statement->execute();
        return $statement->get_result()->fetch_assoc();
    }

    /**
     * @POST
     * @param $id
     * @param $product
     * @param $name
     * @param $price
     * @param $quantity
     * @param $categoryId
     * @param $promotion
     * @return bool
     */

    public function edit($id, $product, $name, $price, $quantity, $categoryId, $promotion)
    {
        if (empty($name) || $price < 0 || $quantity < 0) {
            return false;
        }

        $statement = self::$db->prepare(
            "UPDATE $product SET name = ?, price = ?, quantity = ?, categoryId = ?, promotion = ? WHERE id = ?");
        $statement->bind_param("sdiiii", $name, $price, $quantity, $categoryId, $promotion, $id);
        $statement->execute();
        return $statement->errno == 0;
    }

    /**
     * @DELETE
     * @param $product
     * @param $id
     * @return bool
     */
    public function delete($product, $id)
    {
        $statement = self::$db->prepare(" DELETE FROM $product WHERE id = ?");
        $statement->bind_param("i", $id);
        $statement->execute();
        return $statement->affected_rows > 0;
    }

    /**
     * @POST
     * @param $promote
     * @return bool
     */
    public function promoteAll($promote)
    {
        $ownerId = $_SESSION['id'];
        $shoes = self::$db->prepare(
            "UPDATE shoes SET promotion = ? WHERE ownerId = ?");
        $shoes->bind_param("ii", $promote, $ownerId);
        $shoes->execute();

        $shirts = self::$db->prepare(
            "UPDATE shirts SET promotion = ? WHERE ownerId = ?");
        $shirts->bind_param("ii", $promote, $ownerId);
        $shirts->execute();

        return $shirts->errno == 0;
    }
}