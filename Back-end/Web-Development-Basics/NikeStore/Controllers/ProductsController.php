<?php
namespace NikeStore\Controllers;

class ProductsController extends BaseController
{
    private $productModel;

    public function onInit(){
        $this->productModel = new \NikeStore\Models\ProductsModel();
    }

    public function index()
    {
        $this->authorize();
        $this->shoes = $this->productModel->getAllShoes();
        $this->shirts = $this->productModel->getAllShirts();
    }

    /**
     * @POST
     */
    public function add()
    {
        $this->authorize();
        $this->categories = $this->productModel->getCategories();
        if($this->isPost) {

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

            if($this->productModel->add($name, $price, $quantity, $product, $categoryId, $discount)) {
                $this->addInfoMessage('The product is add.');
                $this->redirect('products');
            } else {
                $this->addErrorMessage('Error creating the shoes.');
            }

        }
    }

    /**
     * @POST shirts
     * @param $id
     * @param $product
     */
    public function edit($product, $id)
    {
        $this->authorize();
        if ($this->isPost) {
            // Edit products
            $name = $this->escape($_POST['name']);
            $price = $this->escape($_POST['price']);
            $quantity = $this->escape($_POST['quantity']);
            $categoryId = $this->escape($_POST['categoryId']);
            $promotion = $this->escape($_POST['promotion']);

            if ($this->productModel->edit($id, $product, $name, $price, $quantity, $categoryId, $promotion)) {
                $this->addInfoMessage("The product is edited.");
                $this->redirect("products");
            } else {
                $this->addErrorMessage("Cannot edit the product.");
            }
        }

        // Display products
        $this->categories = $this->productModel->getCategories();
        $this->product = $this->productModel->find($product, $id);
        if (!$this->product) {
            $this->addErrorMessage("Invalid shirt.");
            $this->redirect("products");
        }
    }

    /**
     * @DELETE shirt
     * @param $product
     * @param $id
     */
    public function delete($product, $id){
        $this->authorize();
        if($this->productModel->delete($product, $id)) {
            $this->addInfoMessage('Product deleted.');
        } else {
            $this->addErrorMessage('Cannot delete the product.');
        }

        $this->redirect('products');
    }

    /**
     * @POST
     */
    public function promoteAll()
    {
        $this->authorize();
        if($this->isPost){
            $promote = $this->escape($_POST['promotion']);

            $this->all = $this->productModel->promoteAll($promote);
            if(!$this->all){
                $this->addErrorMessage('Error in promoting all products.');
                return;
            }
            $this->addInfoMessage('All products are promoted with '. $promote.'%.');
            $this->redirect('products');
        }
    }
}