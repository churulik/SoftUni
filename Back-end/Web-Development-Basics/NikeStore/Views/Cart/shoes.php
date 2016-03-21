<h1>Cart</h1>
<?php
require_once 'item.php';

if($this->shoes){
    $item = new NikeStore\Views\Cart\Item();
    $item->id = $this->shoes['id'];
    $item->name = $this->shoes['name'];
    $item->ownerQuant = $this->shoes['quantity'];
    $item->quantity = 1;
    $item->ownerId = $this->shoes['ownerId'];
    $item->product = 'shoes';
    $promotion = $this->shoes['promotion'];
    $discountPerProduct = ($this->shoes['promotion'] / 100) * $this->shoes['price'];
    $discount = $this->shoes['price'] - $discountPerProduct;
    $item->price = $discount;

    $firstItem = false;
    $index = -1;

    if(!isset($_SESSION['cart'])){
        $_SESSION['cart'][] = $item;
        $firstItem = true;
    }
    $cart = unserialize(serialize($_SESSION['cart']));

    for($i = 0; $i < count($cart); $i++) {
        if($cart[$i]->id == $this->shoes['id']) {
            $index = $i;
            break;
        }
    }

    if($index == -1) {
        $_SESSION['cart'][] = $item;
    } elseif ($index > -1 && !$firstItem) {
        $cart[$index]->quantity++;
        if($cart[$index]->quantity > $this->shoes['quantity']) {
            $this->addErrorMessage($this->shoes['name']." is out of stock.");
        } else {
            $_SESSION['cart'] = $cart;
        }

    }
}

?>

<table cellpadding="2" cellspacing="2" border="1" class="tablecart">
    <tr>
        <th>Option</th>
        <th>Name</th>
        <th>Price</th>
        <th>Quantity</th>
        <th>Sub Total</th>

    </tr>
    <?php
    $cart = unserialize(serialize($_SESSION['cart']));
    $sum = 0;
    $index = 0;
    for($i = 0; $i < count($cart); $i++) {
        $sum += $cart[$i]->price * $cart[$i]->quantity;
    ?>
        <tr>
            <td><a href="/cart/index/<?= $cart[$i]->id ?>?index=<?= $index ?>" onclick="return confirm('Are you sure?')">Remove</a></td>
            <td><?= $cart[$i]->name;  ?></td>
            <td><?= $cart[$i]->price;  ?></td>
            <td><?= $cart[$i]->quantity;  ?></td>
            <td><?= $cart[$i]->price * $cart[$i]->quantity;  ?></td>

        </tr>
    <?php
        $index++;
    } ?>
    <tr>
        <td colspan="4" align="right">Sum</td>
        <td><?= $sum ?></td>
    </tr>
</table>
<div class="cardmenu">
    <div class="button">
        <a href="/shoes" >Continue shopping shoes</a>
    </div>
    <div class="button">
        <a href="/shirts">Continue shopping shirts</a>
    </div>
    <div class="checkout">
        <a href="/cart/checkout">Check out</a>
    </div>
</div>