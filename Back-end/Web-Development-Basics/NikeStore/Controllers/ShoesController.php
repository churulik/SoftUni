<?php
namespace NikeStore\Controllers;

use NikeStore\Models\ShoesModel;

class ShoesController extends BaseController
{   private $shoesModel;

    public function onInit(){
        $this->shoesModel = new ShoesModel();
    }

    public function index()
    {
        $this->shoes = $this->shoesModel->getAll();
    }


}