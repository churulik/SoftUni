<?php
namespace NikeStore\Controllers;

class EditorController extends BaseController
{
    private $editorModel;

    public function onInit()
    {
        $this->editorModel = new \NikeStore\Models\EditorModel();
    }

    public function index()
    {
        $this->editorAuthorize();
    }
    /**
     * @POST login
     */
    public function login()
    {

        if($this->isPost){
            $username = htmlentities(trim($_POST['username']));
            $pass = htmlentities(trim($_POST['password']));
            $isLogged = $this->editorModel->login($username, $pass);
            if($isLogged) {
                $_SESSION['editor'] = $username;
                $this->addInfoMessage("Logged");
                $this->redirect('home');
            } else {
                $this->addErrorMessage("Login failed!");
            }
        }
    }

    /**
     * @GET categories
     */
    public function categories()
    {
        $this->editorAuthorize();
        $this->categories = $this->editorModel->getCategories();
    }

    /**
     * @POST category
     */
    public function addCategories()
    {
        $this->editorAuthorize();

        if($this->isPost) {
            $category = $this->escape($_POST['categoryName']);

            $this->categories = $this->editorModel->addCategories($category);

            if(!$this->categories){
                $this->addErrorMessage('Error while adding.');
                return;
            }
            $this->addInfoMessage('Category add.');
        }
    }
    /**
     * @DELETE categories
     * @param $id
     */
    public function deleteCategory($id){
        $this->editorAuthorize();
        if($this->editorModel->deleteCategory($id)) {
            $this->addInfoMessage('Category deleted.');
        } else {
            $this->addErrorMessage('Cannot delete the category.');
        }

        $this->redirect('editor', 'categories');
    }
    //Products
    /**
     * @GET products
     */
    public function products()
    {
        $this->editorAuthorize();
        $this->shoes = $this->editorModel->getShoes();
        if(!$this->shoes){
            $this->addErrorMessage("Error getting the shoes.");
            return;
        }
        $this->shirts = $this->editorModel->getShirts();
        if(!$this->shirts){
            $this->addErrorMessage("Error getting the shirts.");
            return;
        }
    }

    /**
     * @POST products
     */
    public function addProducts()
    {
        if($this->isPost){
            $name = $this->escape($_POST['name']);
            $price = $this->escape($_POST['price']);
            $quantity = $this->escape($_POST['quantity']);
            $product = $this->escape($_POST['product']);
            $categoryId = $this->escape($_POST['categoryId']);
            $discount = $this->escape($_POST['promotion']);

            if(strlen($name) < 2 || empty($name)){
                $this->addErrorMessage("The product name should be greater than 2.");
                $this->renderView(__FUNCTION__);
                return;
            }

            if($price < 0){
                $this->addErrorMessage("The product price cannot be negative.");
                $this->renderView(__FUNCTION__);
                return;
            }
            if($quantity < 0){
                $this->addErrorMessage("The product price cannot be negative.");
                $this->renderView(__FUNCTION__);
                return;
            }

            if($this->editorModel->addProducts($name, $price, $quantity, $product, $categoryId, $discount)) {
                $this->addInfoMessage('The product is add.');
                $this->redirect('editor','products');
            } else {
                $this->addErrorMessage('Error creating the '. $product );
            }
        }

        $this->categories = $this->editorModel->getCategories();
    }

    /**
     * @POST product
     * @param $product
     * @param $id
     */
    public function editProduct($product, $id)
    {
        if ($this->isPost) {
            // Edit shoes
            $quantity = $this->escape($_POST['quantity']);
            $categoryId = $this->escape($_POST['categoryId']);

            if ($this->editorModel->editproduct($id, $product, $quantity, $categoryId)) {
                $this->addInfoMessage("Shoes edited.");
                $this->redirect('editor', 'products');
            } else {
                $this->addErrorMessage("Cannot edit the shoes.");
            }
        }
        // Display shoes
        $this->categories = $this->editorModel->getCategories();
        $this->product = $this->editorModel->find($product, $id);

        if (!$this->product) {
            $this->addErrorMessage("Invalid product.");
            $this->redirect('editor', 'products');
        }
    }

    /**
     * @DELETE shoes
     * @param $product
     * @param $id
     */
    public function delete($product, $id){
        $this->editorAuthorize();
        if($this->editorModel->deleteProduct($product, $id)) {
            $this->addInfoMessage('Product deleted.');
        } else {
            $this->addErrorMessage('Cannot delete the product.');
        }

        $this->redirect('editor', 'products');
    }

    public function reorder()
    {
        if($this->isPost) {
            $orderShoes = $_POST['ordershoes'];
            $orderShirts = $_POST['ordershirts'];

            $this->orderBy = $this->editorModel->reorder($orderShoes, $orderShirts);
            if(!$this->orderBy){
                $this->addErrorMessage('Error ordering the products');
                return;
            }
            $this->addInfoMessage('Shoes are ordered by '.$orderShoes.'.');
            $this->addInfoMessage('Shirts are ordered by '.$orderShirts.'.');
        }
    }
}