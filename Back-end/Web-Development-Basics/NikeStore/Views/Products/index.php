<h1>My products</h1>
<div>
    <a href="/products/promoteall" id="checkoutBtn">Promote all products</a>
</div>
<h2>Shoes</h2>


<?php foreach($this->shoes as $shoe) : ?>
    <div class="shoes">
        <div><?= $shoe['name'] ?></div>
        <div>$<?= $shoe['price'] ?></div>
        <div><?= $shoe['categoryName'] ?></div>
        <div>In stoke: <?= $shoe['quantity'] ?></div>
        <div>Discount: <?= $shoe['promotion'].'%' ?></div>
        <div><a href="/products/edit/<?= strtolower($shoe['product']).'/'.$shoe['id'] ?>" id="editBtn"><b>Edit</b></a></div>
        <div><a href="/products/delete/<?= strtolower($shoe['product']).'/'.$shoe['id'] ?>" id="deleteBtn"
           onclick="return confirm('Are you sure?')"><b>Delete</b></a></div>
    </div>
<?php endforeach ?>


<h2>Shirts</h2>
    <?php foreach($this->shirts as $shirt) : ?>
        <div class="shirts">
            <div><?= $shirt['name'] ?></div>
            <div>$<?= $shirt['price'] ?></div>
            <div><?= $shirt['categoryName'] ?></div>
            <div>In stoke: <?= $shirt['quantity'] ?></div>
            <div>Discount: <?= $shirt['promotion'].'%' ?></div>
            <div><a href="/products/edit/<?= strtolower($shirt['product']).'/'.$shirt['id'] ?>" id="editBtn"><b>Edit</b></a></div>
            <div><a href="/products/delete/<?= strtolower($shirt['product']).'/'.$shirt['id'] ?>" id="deleteBtn"
                    onclick="return confirm('Are you sure?')"><b>Delete</b></a></div>
        </div>
    <?php endforeach; ?>
