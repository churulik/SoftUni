<?php
if(isset($_SESSION['messages'])){

    foreach($_SESSION['messages'] as $msg){
        echo '<p class="' . $msg['type'] . '">';
        echo $msg['text'];
        echo '</p>';
    }
    unset($_SESSION['messages']);
}
