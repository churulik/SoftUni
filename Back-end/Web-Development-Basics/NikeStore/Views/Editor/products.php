<h1>Shoes</h1>
<?php foreach($this->shoes as $shoe) : ?>
    <div class="shoes">
        <div><?= $shoe['name'] ?></div>
        <div>$<?= $shoe['price'] ?></div>
        <div>Quantity: <?= $shoe['quantity'] ?></div>
        <div><a href="/editor/editproduct/<?= strtolower($shoe['product']).'/'.$shoe['id'] ?>"><b>Edit</b></a></div>
        <div><a href="delete/<?= strtolower($shoe['product']).'/'.$shoe['id'] ?>"
                onclick="return confirm('Are you sure?')"><b>Delete</b></a></div>
    </div>
<?php endforeach ?>

<h1>Shirts</h1>
<?php foreach($this->shirts as $shirt) : ?>
    <div class="shirts">
        <div><?= $shirt['name'] ?></div>
        <div>$<?= $shirt['price'] ?></div>
        <div>Quantity: <?= $shirt['quantity'] ?></div>
        <div><a href="/editor/editproduct/<?= strtolower($shirt['product']).'/'.$shirt['id'] ?>"><b>Edit</b></a></div>
        <div><a href="delete/<?= strtolower($shirt['product']).'/'.$shirt['id'] ?>"
                onclick="return confirm('Are you sure?')"><b>Delete</b></a></div>
    </div>
<?php endforeach ?>
<div>
    <a href="addproducts">Add Product</a>
</div>


