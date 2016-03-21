<?php
namespace NikeStore\Controllers;

use NikeStore\Models\ShirtsModel;

class ShirtsController extends BaseController
{
    private $shirtsModel;

    public function onInit(){
        $this->shirtsModel = new ShirtsModel();
    }

    public function index()
    {
        $this->shirts = $this->shirtsModel->getAll();
    }
}