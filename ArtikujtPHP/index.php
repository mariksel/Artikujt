<?php
require_once("service.php");
require_once('repository.php');

$_SERVICE = new Service();


if(cleanPath() == '/kerko'){

    $pageIndex = 1;
    if (isset($_GET['index'])) {
        $pageIndex = $_GET['index'];
        $pageIndex = max($pageIndex, 1);
    }
    
    kerko($pageIndex);
}
else if(cleanPath() == '/') {
    if(isPost()){
        if (isset($_GET['id'])) {

            $id = $_GET['id'];
    
            indexPOST($id);
    
        } else {
            indexPOST(null);
        }

    } else {
        if (isset($_GET['id'])) {
            $id = $_GET['id'];
    
            indexGET($id);
    
        } else {
            indexGET(null);
        }
    }
    
    
}
else if(cleanPath() == '/artikull/fshi') {
    if(isPost()){
        if (isset($_GET['id'])) {

            $id = $_GET['id'];
    
            fshiPost($id);
        }
    }
    
} else {
    pageNotFoundResponse();
}

function indexGET(?int $id){
    if($id == NULL){
        Service::$page = "artikull.php";
        Service::$title = "Artikull";
    } else {
        $repo = new Repository();
        $artikull = $repo->getArtikull($id);

        if($artikull == NULL){
            Service::$page = "artikull_not_found.php";
            Service::$title = "Artikulli nuk u gjet";

        } else {
            Service::$page = "artikull.php";
            Service::$title = "Artikull";
            Service::$artikull = $artikull;
        }
    }
}

//Ruaj Artikull
function indexPOST(?int $id){

    try {
        $artikull = getArtikull();
        
        $repo = new Repository();
        $artikull->isNew = $id == NULL;
        if($artikull->isNew){
            $repo->addArtikull($artikull);
            Service::createNewArtikull();
            $id = NULL;
        } else {
            $artikull->id = $id;
            $repo->updateArtikull($artikull);
        }
        
        Service::$success = 'Artikulli u ruaj me sukses';
      }
      catch(Exception $e) {
        Service::$error = $e->getMessage();
      }

      indexGET($id);
    
}

// Fshi Artikull
function fshiPost(int $id){
    $repo = new Repository();
    $repo->deleteArtikull($id);
    Service::$success = 'Artikulli u fshi me sukses';
    kerko(1);
}

//Kerko Artikujt
function kerko(int $index){
    Service::$page = "kerko.php";
    Service::$title = "Kerko Artikull";
    $repo = new Repository();
    Service::$pagination = $repo->artikujt($index);
}

require("layout.php");

function getArtikull() : Artikull{
    $artikull = new Artikull();
    if (!IsNullOrEmptyString($_POST['emri'])) {
        $artikull->emri = $_POST['emri'];
    } else {
        throw new Exception("Emri duhet plotesuar");
    }
    if (!IsNullOrEmptyString($_POST['njesia'])) {
        $artikull->njesia = $_POST['njesia'];
    } else {
        throw new Exception("Njesia duhet plotesuar");
    }
    $artikull->dataSkadences = DateTime::createFromFormat('Y-m-d', $_POST['dataSkadences']);
    if (!$artikull->dataSkadences) {
        throw new Exception("Data Skadences duhet plotesuar");
    }
    if (!IsNullOrEmptyString($_POST['cmimi'])) {
        $artikull->cmimi = $_POST['cmimi'];
    } else {
        throw new Exception("Cmimi duhet plotesuar");
    }

    if (!IsNullOrEmptyString($_POST['lloj'])) {
        $artikull->lloj = $_POST['lloj'];
    } else {
        throw new Exception("Lloj duhet plotesuar");
    }

    $artikull->kaTvsh = false;
    if (isset($_POST['kaTvsh'])) {
        $artikull->kaTvsh = $_POST['kaTvsh'];
    }
    

    if (!IsNullOrEmptyString($_POST['tipi'])  && $_POST['tipi']!= Tipi::None) {
        $artikull->tipi = $_POST['tipi'];
    } else {
        throw new Exception("Tipi duhet plotesuar");
    }

    if (!IsNullOrEmptyString($_POST['barkod'])) {
        $artikull->barkod = $_POST['barkod'];
    } else {
        throw new Exception("Barkod duhet plotesuar");
    }

    return $artikull;
}

function pageNotFoundResponse(){
    Service::$page = "page_not_found.php";
    Service::$title = "404 faqja nuk u gjet";
}

function cleanPath(): string{
    return strtok($_SERVER["REQUEST_URI"], '?');
}

function isPost(): bool{
    return $_SERVER['REQUEST_METHOD'] === 'POST' ;
}

function IsNullOrEmptyString($str){
    return (!isset($str) || trim($str) === '');
}

function stringToBool($str ){
    return  $str == 'true';
}