<?php
namespace NikeStore\Controllers;

use NikeStore\BindigModels\RegisterBindingModel;

class AccountController extends BaseController
{
    private $accountModel;

    public function onInit()
    {
        $this->accountModel = new \NikeStore\Models\AccountModel();
    }

    /**
     * @POST
     */
    public function register()
    {
        if($this->isPost) {
            $username = $this->escape($_POST['username']);
            if(empty($username) || strlen($username) < 3 || strlen($username) > 20){
                $this->addErrorMessage('The username should have between 3 and 20 characters.');
                $this->redirect('account', 'register');
                return;
            }
            $password = $this->escape($_POST['password']);

            if(strlen($password) < 1 || strlen($password) > 40){
                $this->addErrorMessage('The password should be between 2 and 40 characters.');
                $this->redirect('account', 'register');
            }
            $confirmPassword = htmlentities(trim($_POST['confirmPassword']));
            if($password !== $confirmPassword){
                $this->addErrorMessage('The password and confirm password does not match.');
                $this->redirect('account', 'register');
            }

            $email = htmlentities(trim($_POST['email']));
            if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
                $this->addErrorMessage('The email is invalide.');
                $this->redirect('account', 'register');
            }

            $isRegister = $this->accountModel->register($username, $password, $email);

            if($isRegister){
                $this->addInfoMessage('Successful registration.');
                $this->redirect('account', 'login');
            }  elseif (isset($_SESSION['username'])) {
                $this->addErrorMessage('Username already exists.');
                unset($_SESSION['username']);
            } else {
                $this->addErrorMessage('Email already registered.');
            }
        }
        $this->renderView(__FUNCTION__);
    }

    /**
     * @POST
     */
    public function login()
    {
        if($this->isPost){
            $username = htmlentities(trim($_POST['username']));
            $pass = htmlentities(trim($_POST['password']));
            $isLogged = $this->accountModel->login($username, $pass);
            if($isLogged) {
                $_SESSION['username'] = $username;
                $this->addInfoMessage("Logged");
                $this->redirect('home');
            } else {
                $this->addErrorMessage("Login failed!");
            }
        }
        $this->renderView(__FUNCTION__);
    }

    public function logout()    {
        session_destroy();
        $this->addInfoMessage("You are logged out");
        $this->redirectToUrl("/");
    }

    public function profile()
    {
        $this->authorize();
        $this->accountModel->profile();
    }
}