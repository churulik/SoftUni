<h1>Edit shoes</h1>

<?php if ($this->shoes) { ?>
    <form method="post" action="/products/editshoes/<?= $this->shoes['id'] ?>">
        Name:
        <input type="text" name="name"
               value="<?= htmlspecialchars($this->shoes['name']) ?>" />
        <br/>
        Price:
        <input type="number" name="price"
               value="<?= htmlspecialchars($this->shoes['price']) ?>" />
        <br/>
        Quantity
        <input type="number" name="quantity"
               value="<?= htmlspecialchars($this->shoes['quantity']) ?>" />
        <br/>
        Category:
        <?php foreach($this->categories as $category) : ?>
            <input type="radio" name="categoryId" value="<?= $category['id'] ?>" checked/> <?= $category['categoryName'] ?>
        <?php endforeach; ?>
        <br/>
        <input type="submit" value="Edit" />
        <a href="/products">Cancel</a>
    </form>
<?php } ?>



