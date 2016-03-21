<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>NikeStore</title>
    <link rel="stylesheet" href="/content/styles.css">
    <link rel="stylesheet" href="/content/animate.css">
    <script src="http://code.jquery.com/jquery-2.1.4.min.js"></script>
</head>

<body>

<header>
    <a href="/"><img src="/content/images/store.png" id="store"></a>
    <ul id="mainmenu">
            <li class="home"><a href="/">Home</a></li>
            <li><a href="/shoes">Shoes</a></li>
            <li><a href="/shirts">Shirts</a></li>
            <li><a href="/helpdesk">Help desk</a></li>
        <?php if(!$this->isLoggedIn && !$this->editorLoggedIn && !isset($_SESSION['admin'])) : ?>
            <li class="product"><a href="/account/register">Register</a></li>
            <li><a href="/account/login">Login</a></li>
        <?php endif;?>

        <?php if($this->isLoggedIn) : ?>
            <li class="product"><a href="/products">My products</a></li>
            <li class="product"><a href="/products/add">Add product</a></li>
            <li class="product"><a href="/account/profile">Profile</a></li>
            <li class="logout"><a href="/account/logout">Logout</a></li>
            <li class="logo">
                <a href="/">
                    <img src="/content/images/nikelogo.png" alt="">
                </a>
                <a href="/account/profile" class="menuprofile">
                    Hello, <?= $_SESSION['username']; ?>
                </a>
            </li>
            <li class="cart"><a href="/cart/index/1?index"><img src="/content/images/cart.png" alt=""></a></li>
        <?php endif;?>

        <?php if($this->editorLoggedIn) : ?>
            <li><a href="/editor">Editor</a></li>
            <li class="logout"><a href="/account/logout">Logout</a></li>
            <li class="logo">
                <a href="/">
                    <img src="/content/images/nikelogo.png" alt="">
                </a>
                <a href="/editor" class="menuprofile">
                    Hello, <?= $_SESSION['editor']; ?>
                </a>
            </li>
        <?php endif;?>

        <?php if(isset($_SESSION['admin'])) : ?>
            <li class="product"><a href="/products">My products</a></li>
            <li class="product"><a href="/products/add">Add product</a></li>
            <li class="product"><a href="/account/profile">Profile</a></li>
            <li><a href="/editor">Editor</a></li>
            <li class="logout"><a href="/account/logout">Logout</a></li>
            <li class="logo">
                <a href="/">
                    <img src="/content/images/nikelogo.png" alt="">
                </a>
                <a href="/account/profile" class="menuprofile">
                    Hello, <?= $_SESSION['admin']; ?></li>
                </a>
            <li class="cart"><a href="/cart/index/1?index"><img src="/content/images/cart.png" alt=""></a></li>
        <?php endif;?>
    </ul>

</header>

<?php if(!isset($_SESSION['categories'])) {
    $_SESSION['categories'] = array();
} ?>

<p class="category">Choose the one that fits you best >>
<?php foreach($_SESSION['categories'] as $category) : ?>
    <span class="categoryProduct"><a href="/category/choose/<?= strtolower($category['categoryName']) ?>"><?= $category['categoryName'] ?></a></span>
<?php endforeach; ?>
</p>

<?php include_once('views/layouts/messages.php'); ?>


