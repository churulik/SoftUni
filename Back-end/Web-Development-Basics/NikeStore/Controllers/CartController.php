<?php
namespace NikeStore\Controllers;

class CartController extends BaseController
{
    private $cartModel;

    public function onInit()
    {
        $this->cartModel = new \NikeStore\Models\CartModel();
    }
    public function index()
    {
        $this->authorize();
    }

    public function shoes($id)
    {
        $this->authorize();

        $this->shoes = $this->cartModel->findShoes($id);

        if (!$this->shoes) {
            $this->addErrorMessage("Invalid product.");
            $this->redirect("shoes");
        }

    }

    public function shirts($id)
    {
        $this->authorize();

        $this->shirt = $this->cartModel->findShirt($id);

        if (!$this->shirt) {
            $this->addErrorMessage("Invalid product.");
            $this->redirect("shoes");
        }

    }

    public function checkout()
    {
        if($this->isPost) {

            $this->checkout = $this->cartModel->updateOwnerBalance();
            if(!$this->checkout) {
                $this->addErrorMessage("Your balance is not enough to purchase the items.");
                return;
            }
            $this->update = $this->cartModel->updateSellersBalance();
            $this->addInfoMessage("Successful purchase.");
            unset($_SESSION['cart']);
            unset($_SESSION['sum']);
            $this->redirect("cart");
        }

    }

}