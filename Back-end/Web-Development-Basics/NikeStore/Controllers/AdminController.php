<?php
namespace NikeStore\Controllers;

class AdminController extends BaseController
{
    private $db;

    public function onInit()
    {
        $this->db = new \NikeStore\Models\AdminModel();
    }

    public function login()
    {
        if($this->isPost){
            $username = htmlentities(trim($_POST['username']));
            $pass = htmlentities(trim($_POST['password']));
            $isLogged = $this->db->login($username, $pass);
            if($isLogged) {
                $_SESSION['admin'] = $username;
                $_SESSION['id'] = 1;
                $this->addInfoMessage("Logged");
                $this->redirect('home');
            } else {
                $this->addErrorMessage("Login failed!");
            }
        }
    }
}