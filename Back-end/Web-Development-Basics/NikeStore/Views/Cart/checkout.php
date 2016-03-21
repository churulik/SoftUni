<?php
if (isset ($_SESSION['cart'])) {
    if(!isset($_SESSION['sum'])){
        $_SESSION['sum'] = 0;
    }
    $cart = unserialize(serialize($_SESSION['cart']));
    $sum = 0;
    $index = 0;
?>
    <table cellpadding="2" cellspacing="2" border="1" class="tablecart">
    <tr>
        <th>Name</th>
        <th>Price</th>
        <th>Quantity</th>
        <th>Sub Total</th>

    </tr>
    <?php
    for($i = 0; $i < count($cart); $i++) {
        $sum += $cart[$i]->price * $cart[$i]->quantity;
        ?>
        <tr>
            <td><?= $cart[$i]->name;  ?></td>
            <td><?= $cart[$i]->price;  ?></td>
            <td><?= $cart[$i]->quantity;  ?></td>
            <td><?= $cart[$i]->price * $cart[$i]->quantity;  ?></td>

        </tr>
        <?php
        $index++;
    }
    $_SESSION['sum'] = $sum;
    ?>
        <tr>
            <td colspan="3" align="right">Sum</td>
            <td><?= $sum ?></td>
        </tr>
    </table>
    <div class="cardmenu">
        <form action="/cart/checkout" method="post">
            <input type="submit" name="checkout" value="Check out" id="checkoutBtn"/>
        </form>
        <div >
            <a href="/cart" class="cancelBtn">Cancel</a>
        </div>
    </div>


    <?php
    } else {
        echo '<p>Your cart is empty.</p>';
    }
