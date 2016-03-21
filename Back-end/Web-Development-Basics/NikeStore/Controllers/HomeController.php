<?php
namespace NikeStore\Controllers;

class HomeController extends BaseController
{
    private $homeModel;
    public function onInit()
    {
        $this->homeModel = new \NikeStore\Models\HomeModel();
    }
    public function index()
    {
        $_SESSION['categories'] = $this->homeModel->getAllCategories();
    }

}