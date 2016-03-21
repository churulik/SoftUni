<?php
namespace NikeStore\Models;

class HomeModel extends BaseModel
{
    public function getAllCategories()
    {
        $stmt = self::$db->query("SELECT categoryName FROM categories");
        return $stmt->fetch_all(MYSQLI_ASSOC);
    }
}