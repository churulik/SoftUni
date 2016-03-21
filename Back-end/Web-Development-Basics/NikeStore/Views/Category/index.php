
<span>Choose the one that fits you best: </span>
<?php foreach($this->categories as $category) : ?>
    <span><a href="/category/choose/<?= strtolower($category['categoryName']) ?>"><?= $category['categoryName'] ?></a></span>
<?php endforeach; ?>



