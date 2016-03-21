<?php
namespace NikeStore\Areas\Controllers;

use NikeStore\Controllers\BaseController;

class ContactusController extends BaseController
{
    private $contactusModel;
    public function onInit()
    {
        $this->contactusModel = new \NikeStore\Areas\Models\ContactusModel();
    }
    public function index()
    {

    }
    public function response()
    {
        if($this->isPost) {
            $name = $this->escape($_POST['name']);
            $email = $this->escape($_POST['email']);
            $text = $this->escape($_POST['text']);

            if(empty($name)){
                $this->info = "Enter a valid name.";
            } elseif (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
                $this->info = "Enter a valid email.";
            } elseif (empty($text)) {
                $this->info = "Enter a valid message.";
            } else {
                $this->info = "Your message has been successfully send.";
            }

            $this->contactusModel->add($name, $email, $text);

            if(!$this->contactusModel) {
                $this->addErrorMessage('Error adding the information');
                $this->redirect('contactus', 'index');
            }
        }

        $this->renderAreaView(__FUNCTION__,false);
    }
}