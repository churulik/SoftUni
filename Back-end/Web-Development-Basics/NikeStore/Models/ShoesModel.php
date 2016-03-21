<?php
namespace NikeStore\Models;

class ShoesModel extends BaseModel
{
    /**
     * @GET
     * @return mixed
     */
    public function getAll()
    {
        $stmt = self::$db->query ("SELECT orderBy FROM shoes LIMIT 1");
        $order = $stmt->fetch_row();

        if(!isset($_SESSION['username'])) {
            $stmt = self::$db->query
            ("SELECT s.id, s.name, c.categoryName, s.price, s.quantity, s.promotion
                FROM shoes s, categories c
                WHERE s.categoryId = c.Id
                AND s.quantity > 0
                ORDER BY s.$order[0]");

            return $stmt->fetch_all(MYSQLI_ASSOC);
        } else {
            $user  = $_SESSION['id'];
            $stmt = self::$db->query
            ("SELECT s.id, s.name, c.categoryName, s.price, s.quantity, s.promotion
                FROM shoes s, categories c
                WHERE s.categoryId = c.Id
                AND ownerId != $user
                AND s.quantity > 0
                ORDER BY s.$order[0]");

            return $stmt->fetch_all(MYSQLI_ASSOC);
        }

    }
}