<?php
namespace NikeStore\Models;

class CategoryModel extends BaseModel
{
    /**
     * @param $categoryName
     * @return mixed
     */
    public function get($categoryName)
    {
        if(!isset($_SESSION['username'])) {
            $stmt = self::$db->query ("SELECT s.name, s.price, s.quantity, c.categoryName, s.promotion
                                          FROM categories c, shoes s
                                          WHERE c.id = s.categoryid
                                          AND categoryName = '$categoryName'
                                          AND s.quantity > 0");
            return $stmt->fetch_all(MYSQLI_ASSOC);
        } else {
            $ownerId = $_SESSION['id'];
            $stmt = self::$db->query ("SELECT s.name, s.price, s.quantity, c.categoryName, s.promotion
                                          FROM categories c, shoes s
                                          WHERE c.id = s.categoryid
                                          AND categoryName = '$categoryName'
                                          AND s.ownerId != $ownerId
                                          AND s.quantity > 0");
            return $stmt->fetch_all(MYSQLI_ASSOC);
        }

    }
    public function getCategories()
    {
        $stmt = self::$db->query("SELECT id, categoryName FROM categories");
        return $stmt->fetch_all(MYSQLI_ASSOC);
    }
}