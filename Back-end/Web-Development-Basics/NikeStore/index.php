<?php
session_start();

require_once 'Configs\Configs.php';

$uri = parse_url($_SERVER['REQUEST_URI'],PHP_URL_PATH);
$requestUri = explode('/', $uri);
$requestUri = array_filter($requestUri);

$areaName = DEFAULT_AREA;
$controllerName = DEFAULT_CONTROLLER;
$actionName = DEFAULT_ACTION;

if(count($requestUri) != 0 && strtolower($requestUri[1]) == 'helpdesk'){
    $areaName = array_shift($requestUri);
}

if(count($requestUri) != 0){
    $controllerName = array_shift($requestUri);
    if (! preg_match('/^[a-zA-Z0-9_-]+$/', $controllerName)) {
        die('Invalid controller name. Use letters, digits,dash and underscore only.');
    }
}

if(count($requestUri) != 0){
    $actionName = array_shift($requestUri);

    if (! preg_match('/^[a-zA-Z0-9_-]+$/', $actionName)) {
        die('Invalid action name. Use letters, digits,dash and underscore only.');
    }
}

$params = $requestUri;

$controllerClassName = '\\NikeStore\\Controllers\\'.ucfirst($controllerName).'Controller';
$controllerFileName = $controllerClassName.'.php';


spl_autoload_register(function($class) {

    $split = explode('\\',$class);
    array_shift($split);
    $fullClassName = implode(DIRECTORY_SEPARATOR, $split);

    if(file_exists('areas/'.$fullClassName.'.php')) {
        require_once 'areas/'.$fullClassName.'.php';
    }
    if(file_exists("areas/models/$class.php")){
        require_once "areas/Models/$class.php";
    }
    if(file_exists($fullClassName.'.php')){
        require_once $fullClassName.'.php';
    }

    if(file_exists("models/$class.php")){
        require_once "models/$class.php";
    }
});

if($areaName == null) {
    if(class_exists($controllerClassName)){
        $controller = new $controllerClassName($controllerName, $actionName);
    } else {
        //Public comment
        header('HTTP/1.0 404 Not Found');
        echo "<h1>Error 404 Not Found</h1>";
        echo "The page that you have requested could not be found.";
        exit();
        //Developer comment
        die("Error: cannot find controller '$controllerName' in class '$controllerFileName'.");
    }

    if(method_exists($controller, $actionName)){
        call_user_func_array(array($controller, $actionName), $params);
    } else {
        //Public comment
        header('HTTP/1.0 404 Not Found');
        echo "<h1>Error 404 Not Found</h1>";
        echo "The page that you have requested could not be found.";
        exit();
        //Developer comment
        die("Error: cannot find action '$actionName' in controller '$controllerClassName'.");
    }

    $controller->renderView();
} else {
    $areasControllerClassName = '\\NikeStore\\Areas\\Controllers\\'.ucfirst($controllerName).'Controller';
    $areasControllerFileName = $areasControllerClassName.'.php';

    if(class_exists($areasControllerClassName)){
        $controller = new $areasControllerClassName($controllerName, $actionName);
    } else {
        //Public comment
        header('HTTP/1.0 404 Not Found');
        echo "<h1>Error 404 Not Found</h1>";
        echo "The page that you have requested could not be found.";
        exit();
        //Developer comment
        die("Error: cannot find controller '$controllerName' in class '$areasControllerFileName'.");
    }

    if(method_exists($controller, $actionName)){

        call_user_func_array(array($controller, $actionName), $params);
    } else {
        //Public comment
        header('HTTP/1.0 404 Not Found');
        echo "<h1>Error 404 Not Found</h1>";
        echo "The page that you have requested could not be found.";
        exit();
        //Developer comment
        die("Error: cannot find action '$actionName' in controller '$controllerClassName'.");
    }
    $controller->renderAreaView();
}

/**
 * NOTE: There is no editor or admin registration form.
 * In order to login as editor go to: localhost/editor/login.
 * In order to login as admin go to: localhost/admin/login.
 *
 */





