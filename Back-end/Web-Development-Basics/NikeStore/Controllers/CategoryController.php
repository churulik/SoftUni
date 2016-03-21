<?php
namespace NikeStore\Controllers;

class CategoryController extends BaseController
{
    private $categoryModel;

    public function onInit()
    {
        $this->categoryModel = new \NikeStore\Models\CategoryModel();
    }

    public function index()
    {
    }

    public function choose($categoryName)
    {
        $this->category = ucfirst($categoryName);
        $this->categories = $this->categoryModel->get($categoryName);
    }
}