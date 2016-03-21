<?php
namespace NikeStore\Models;

class AdminModel extends BaseModel
{
    /**
     * @param $username
     * @param $password
     * @return bool
     */
    public function login($username, $password)
    {
        $stmt = self::$db->prepare("SELECT username, password FROM admins Where username = ?");
        $stmt->bind_param("s", $username);
        $stmt->execute();
        $result = $stmt->get_result()->fetch_assoc();

        if($password == $result['password']) {
            return true;
        }
        return false;
    }
}