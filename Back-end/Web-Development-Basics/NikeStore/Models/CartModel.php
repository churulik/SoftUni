<?php
namespace NikeStore\Models;

class CartModel extends BaseModel
{
    /**
     * @GET
     * @param $id
     * @return array
     */
    public function findShoes($id)
    {
        $statement = self::$db->prepare(
            "SELECT id, name, price, quantity, ownerId, promotion FROM shoes WHERE id = ?");
        $statement->bind_param("i", $id);
        $statement->execute();
        return $statement->get_result()->fetch_assoc();
    }

    /**
     * @GET
     * @param $id
     * @return array
     */
    public function findShirt($id)
    {

        $statement = self::$db->prepare(
            "SELECT id, name, price, quantity, ownerId, promotion FROM shirts WHERE id = ?");
        $statement->bind_param("i", $id);
        $statement->execute();
        return $statement->get_result()->fetch_assoc();
    }

    /**
     * @return bool
     */
    public function updateOwnerBalance()
    {
        $sum = $_SESSION['sum'];
        $username = $_SESSION['username'];

        $statement = self::$db->query(
            "SELECT username, cash FROM users WHERE username = '$username'");

        $result = $statement->fetch_assoc();

        $balance = $result['cash'] - $sum;
        if($balance < 0) {
            return false;
        }

        $statement = self::$db->prepare(
            "UPDATE users SET cash = ? WHERE username = ? ");
        $statement->bind_param("ds", $balance, $username);
        $statement->execute();

        return $statement->errno == 0;
    }

    /**
     * @return bool
     */
    public function updateSellersBalance()
    {
        $cart = $_SESSION['cart'];


        foreach($cart as $k => $v) {
            $product = get_object_vars($v)['product'];
            $productPrice  = get_object_vars($v)['price'];
            $quantity = get_object_vars($v)['quantity'];
            $ownerId = get_object_vars($v)['ownerId'];
            $ownerQuant = get_object_vars($v)['ownerQuant'];

            $statement = self::$db->query(
                "SELECT u.username, u.cash
                  FROM users u, $product s
                  WHERE u.Id = s.ownerId
                  AND s.ownerId = $ownerId");

            $user = $statement->fetch_assoc();

            $username = $user['username'];
            $userCash = $user['cash'];
            $balance = $userCash + $productPrice;

            $statement = self::$db->prepare(
                "UPDATE users SET cash = ? WHERE username = ? ");
            $statement->bind_param("ds", $balance, $username);
            $statement->execute();

            $newQuantityBalance = $ownerQuant - $quantity;

            $statement = self::$db->prepare(
                "UPDATE $product SET quantity = ? WHERE ownerId = ?");
            $statement->bind_param("di", $newQuantityBalance, $ownerId);
            $statement->execute();

            return $statement->errno == 0;
        }
    }
}