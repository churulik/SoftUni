<h1>Edit shirts</h1>

<?php if ($this->shirt) { ?>
    <form method="post" action="/products/editshirt/<?= $this->shirt['id'] ?>">
        Name:
        <input type="text" name="name"
               value="<?= htmlspecialchars($this->shirt['name']) ?>" />
        <br/>
        Price:
        <input type="number" name="price"
               value="<?= htmlspecialchars($this->shirt['price']) ?>" />
        <br/>
        Quantity
        <input type="number" name="quantity"
               value="<?= htmlspecialchars($this->shirt['quantity']) ?>" />
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


