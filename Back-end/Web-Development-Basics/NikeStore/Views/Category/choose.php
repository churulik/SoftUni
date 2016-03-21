<h1>Category <?= $this->category ?></h1>
<img src="/content/images/federer.jpg" alt="" class="shirtsImg">
<div class="categoryItems">
<?php foreach($this->categories as $category) : ?>
    <div>
        <div><?= $category['name'] ?></div>
        <div>$<?= $category['price'] ?></div>
        <div>In stock: <?= $category['quantity'] ?></div>
        <div>Discount: <?= $category['promotion'].'%' ?></div>
    </div>
<?php endforeach ?>
</div>
<p align="right"><a href="/shoes">See more>></a></p>
