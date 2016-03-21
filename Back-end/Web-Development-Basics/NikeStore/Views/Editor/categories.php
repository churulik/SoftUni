<?php foreach($this->categories as $category) : ?>
    <div>
        <?= $category['categoryName'] ?>
        <a href="deletecategory/<?= $category['id'] ?>" onclick="return confirm('Are you sure?')"><b>Delete</b></a>
    </div>
<?php endforeach; ?>
<a href="/editor/addcategories">Add category</a>

