<h1>Add new product</h1>
<form action="/products/add" method="post">
    <fieldset class="register">
        <legend>Add new product</legend>
        <input type="text" name="name" placeholder="Name"/>
        <input type="number" name="price" min="0" placeholder="Price" />
        <input type="number" name="quantity" min="0" placeholder="Quantity" />
        <br/>
        <select name="product" id="" class="dropdown">
            <option value="Shoes">-- Product --</option>
            <option value="Shoes">Shoes</option>
            <option value="Shirts">Shirts</option>
        </select>

        <select name="promotion" id="" class="dropdown">
            <option value="">-- Discount --</option>
            <option value="0">0%</option>
            <option value="10">10%</option>
            <option value="15">15%</option>
            <option value="20">20%</option>
        </select>

        <select name="categoryId" id="" class="dropdown">
            <option value="">-- Category --</option>
            <?php foreach($this->categories as $category) : ?>
                <option value="<?= $category['id'] ?>"><?= $category['categoryName'] ?></option>
            <?php endforeach; ?>
        </select>
        <input type="submit" value="Add">
    </fieldset>
</form>
