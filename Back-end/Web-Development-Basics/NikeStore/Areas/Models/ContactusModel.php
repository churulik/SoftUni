<?php
namespace NikeStore\Areas\Models;

use NikeStore\Models\BaseModel;

class ContactusModel extends BaseModel
{
    /**
     * @POST
     * @param $name
     * @param $email
     * @param $text
     * @return bool
     */
    public function add($name, $email, $text)
    {
        $stmt = self::$db->prepare("INSERT INTO contactus (name, email, text) VALUES (?, ?, ?)");
        $stmt->bind_param("sss", $name, $email, $text);
        $stmt->execute();

        return $stmt->errno == 0;
    }
}