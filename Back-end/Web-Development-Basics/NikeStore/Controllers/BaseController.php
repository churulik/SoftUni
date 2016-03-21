<?php
namespace NikeStore\Controllers;

abstract class BaseController
{
    protected $controllerName;
    protected $actionName;
    protected $layoutName = DEFAULT_LAYOUT;
    protected $isViewRendered = false;
    protected $isPost = false;
    protected $isLoggedIn;
    protected $editorLoggedIn;
    /**
     * BaseController constructor.
     * @param $controllerName
     * @param $actionName
     */
    public function __construct($controllerName, $actionName)
    {
        $this->controllerName = $controllerName;
        $this->actionName = $actionName;
        $this->onInit();
        if($_SERVER['REQUEST_METHOD'] === 'POST'){

            $this->isPost = true;
        }

        if(isset($_SESSION['username'])){
            $this->isLoggedIn = true;
        }

        if(isset($_SESSION['editor'])){
            $this->editorLoggedIn = true;
        }

    }

    public function onInit()
    {

    }

    public function renderAreaView($viewName = null, $includeLayout = true)
    {
        if(!$this->isViewRendered){
            if($viewName == null){
                $viewName = $this->actionName;
            }
            $viewAreaFile = "areas/views/$this->controllerName/$viewName.php";
            if($includeLayout) {
                $headerFile = "views/layouts/$this->layoutName/header.php";
                include_once($headerFile);
            }
            include_once($viewAreaFile);
            if($includeLayout) {
                $footerFile = "views/layouts/$this->layoutName/footer.php";
                include_once($footerFile);
            }
            $this->isViewRendered = true;
        }
    }

    public function renderView($viewName = null, $includeLayout = true)
    {
        if(!$this->isViewRendered){
            if($viewName == null){
                $viewName = $this->actionName;
            }
            $viewFile = "views/$this->controllerName/$viewName.php";
            if($includeLayout) {
                $headerFile = "views/layouts/$this->layoutName/header.php";
                include_once($headerFile);
            }
            include_once($viewFile);
            if($includeLayout) {
                $footerFile = "views/layouts/$this->layoutName/footer.php";
                include_once($footerFile);
            }
            $this->isViewRendered = true;
        }
    }

    public function escape($value){
        return htmlspecialchars(trim($value));
    }

    public function editorAuthorize(){
        if(! $this->editorLoggedIn) {
            $this->redirect('home');
        }
    }
    public function authorize(){
        if(! $this->isLoggedIn && !isset($_SESSION['admin'])) {
            $this->addErrorMessage('Login first');
            $this->redirect('account', 'login');
        }
    }

    public function redirectToUrl($url){
        header("Location: $url");
        die;
    }

    public function redirect($controllerName, $actionName = null, $params = null){
        $url = '/'.urlencode($controllerName);
        if($actionName != null) {

            $url .= '/'.urlencode($actionName);
        }
        if($params != null) {
            $encodedParams = array_map($params, 'urlencode');
            $url .= implode('/', $encodedParams);
        }
        $this->redirectToUrl($url);
    }

    public function addMessage($msg, $type){
        if(!isset($_SESSION['messages'])){
            $_SESSION['messages'] = array();
        }
        array_push($_SESSION['messages'], array('text' => $msg, 'type' => $type));
    }

    public function addInfoMessage($msg){
        $this->addMessage($msg, 'info');
    }

    public function addErrorMessage($msg){
        $this->addMessage($msg, 'error');
    }
}