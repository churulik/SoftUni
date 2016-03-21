<?php if ($this->product) { ?>
    <fieldset class="register">
        <legend>Edit product</legend>
        <form method="post" action="/products/edit/<?= $this->product['product'].'/'.$this->product['id'] ?>">
            Name:
            <input type="text" name="name"
                   value="<?= htmlspecialchars($this->product['name']) ?>" />
            <br/>
            Price:
            <input type="number" name="price"
                   value="<?= htmlspecialchars($this->product['price']) ?>" />
            <br/>
            Quantity
            <input type="number" name="quantity"
                   value="<?= htmlspecialchars($this->product['quantity']) ?>" />
            <br/>
            <select name="promotion" id="" class="dropdown">
                <option value="0">-- Discount --</option>
                <option value="0">0%</option>
                <option value="10">10%</option>
                <option value="15">15%</option>
                <option value="20">20%</option>
            </select>
            <select name="categoryId" id="" class="dropdown">
                <option value="1">-- Category --</option>
                <?php foreach($this->categories as $category) : ?>
                    <option value="<?= $category['id'] ?>"><?= $category['categoryName'] ?></option>
                <?php endforeach; ?>
            </select>
            <input type="submit" value="Edit" />
            <a href="/products" class="cancelBtn">Cancel</a>
        </form>
    </fieldset>

<?php } ?>


