<h1>Shoes</h1>
<img src="/content/images/nikeshoes.jpg" alt="" class="shirtsImg">
<div class="outershoes">
<?php foreach($this->shoes as $shoe) : ?>
    <div class="shoes">
        <div><?= $shoe['name'] ?></div>
        <div>$<?= $shoe['price'] ?></div>
        <div><?= $shoe['categoryName'] ?></div>
        <div>In stoke: <?= $shoe['quantity'] ?></div>
        <div>Discount: <?= $shoe['promotion'].'%' ?></div>
        <a href="/cart/shoes/<?= $shoe['id'] ?>"><b>Order Now</b></a>
    </div>
<?php endforeach ?>
</div>
