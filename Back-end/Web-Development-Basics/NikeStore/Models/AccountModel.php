<?php
namespace NikeStore\Models;

class AccountModel extends BaseModel
{

    /**
     * @param $username
     * @param $password
     * @param $email
     * @return bool
     */
    public function register($username, $password, $email)
    {

        $stmt = self::$db->prepare("SELECT username FROM users WHERE username = ?");
        $stmt->bind_param("s",$username);
        $stmt->execute();
        $result = $stmt->get_result()->fetch_assoc();
        if($result) {
            $_SESSION['username'] = $username;
            return false;
        }

        $stmt = self::$db->prepare("SELECT username FROM users WHERE email = ?");
        $stmt->bind_param("s",$email);
        $stmt->execute();
        $result = $stmt->get_result()->fetch_assoc();
        if($result) {
            return false;
        }
        $pass_hash = password_hash($password,PASSWORD_BCRYPT);
        $role = 'User';
        $cash = 1500;
        $date = date("Y-m-d");

        $stmt = self::$db->prepare
        ("INSERT INTO users (username, pass_hash, email, registeredOn, cash, role) VALUES (?, ?, ?, ?, ?, ?)");
        $stmt->bind_param("ssssds",$username,  $pass_hash, $email, $date, $cash, $role);
        $stmt->execute();

        return true;
    }

    /**
     * @param $username
     * @param $password
     * @return bool
     */
    public function login($username, $password)
    {
        $stmt = self::$db->prepare("SELECT id, username, pass_hash FROM Users Where username = ?");
        $stmt->bind_param("s", $username);
        $stmt->execute();
        $result = $stmt->get_result()->fetch_assoc();

        if(password_verify($password, $result['pass_hash'])) {
            $_SESSION['id'] = $result['id'];
            return true;
        }
        return false;
    }

    public function profile(){
        $stmt = self::$db->prepare("SELECT username, email, cash FROM Users Where username = ?");
        $stmt->bind_param("s", $_SESSION['username']);
        $stmt->execute();
        $result = $stmt->get_result()->fetch_assoc();

        $_SESSION['email'] = $result['email'];
        $_SESSION['cash'] = $result['cash'];
    }


}