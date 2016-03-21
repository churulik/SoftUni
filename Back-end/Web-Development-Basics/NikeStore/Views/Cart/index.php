<h1>Cart</h1>
<?php
if(isset($_SESSION['cart'])){
if(isset($_GET['index'])){
    $cart = unserialize(serialize($_SESSION['cart']));
    unset($cart[$_GET['index']]);
    $cart = array_values($cart);
    $_SESSION['cart'] = $cart;
}
?>
    <?php if(empty($cart) && !isset($_GET['index'])) {
        header("Location: /cart/index/1?index");
        return;
    }
    if(empty($cart)) {
        echo '<p>Your cart is empty.</p>';
        return;
    }?>
    <table cellpadding="2" cellspacing="2" border="1" class="tablecart">
        <tr>
            <td>Option</td>
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
<?php } else  {
    echo '<p>Your cart is empty.</p>';
}
?>