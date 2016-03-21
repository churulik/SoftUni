<h1>Edit product</h1>

<?php if ($this->product) { ?>
    <form method="post" action="">
        Quantity
        <input type="number" name="quantity"
               value="<?= htmlspecialchars($this->product['quantity']) ?>" />
        <select name="categoryId" id="">
            <option value="1">-- Category --</option>
            <?php foreach($this->categories as $category) : ?>
                <option value="<?= $category['id'] ?>"><?= $category['categoryName'] ?></option>
            <?php endforeach; ?>
        </select>
        <input type="submit" value="Edit" />
        <a href="/editor/products">Cancel</a>
    </form>
<?php } ?>