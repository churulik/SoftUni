<h1>Shirts</h1>
<img src="/content/images/nikesrts.jpg" alt="" class="shirtsImg">
<div class="outershirts">
<?php foreach($this->shirts as $shirt) : ?>
    <div class="shirts">
        <div><?= $shirt['name'] ?></div>
        <div>$<?= $shirt['price'] ?></div>
        <div><?= $shirt['categoryName'] ?></div>
        <div>In stoke: <?= $shirt['quantity'] ?></div>
        <div>Discount: <?= $shirt['promotion'].'%' ?></div>
        <a href="/cart/shirts/<?= $shirt['id'] ?>"><b>Order Now</b></a>
    </div>
<?php endforeach ?>
</div>
