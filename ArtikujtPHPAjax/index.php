<?php
require_once("service.php");
require_once('repository.php');
require_once('models/api_response.php');

$_SERVICE = new Service();


if(isApiCall()){
    if(cleanPath() == '/api/artikujt'){

        $pageIndex = 1;
        if (isset($_GET['index'])) {
            $pageIndex = $_GET['index'];
            $pageIndex = max($pageIndex, 1);
        }

        $repo = new Repository();
        $pagination = $repo->artikujt($pageIndex);
        apiResponse($pagination, true, "");
    }
    else if(cleanPath() == '/api/artikull'){
        if(isGet()){
            if (isset($_GET['id'])) {
                $id = $_GET['id'];
                getArtikull($id);
            }
        } else if(isPost()){
            createArtikull();
        } else if (isPut()){
            if (isset($_GET['id'])) {
                $id = $_GET['id'];
                updateArtikull($id);
            }
        }else if (isDelete()){
            if (isset($_GET['id'])) {
                $id = $_GET['id'];
                deleteArtikull($id);
            }
        }
    }
} 
else 
{
    Service::$page = "artikull.php";
    Service::$title = "Artikujt";
    

    require("layout.php");
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


function getArtikull(int $id){

    $repo = new Repository();
    $artikull = $repo->getArtikull($id);

    if($artikull == NULL){
        apiResponse(NULL, false, "Artikulli nuk u gjet");

    } else {
        apiResponse($artikull, true, "");

    }

}

function createArtikull(){
    try{

        $artikull = mapArtikull();
        $repo = new Repository();
        $artikull->isNew = true;
        $repo->addArtikull($artikull);
        $artikull->isNew = false;

        apiResponse($artikull, true, "Artikulli u krijua me sukses");
    }
    catch(Exception $e) {
        apiResponse(NULL, false, $e->getMessage());
    }
}

function updateArtikull(int $id){
    try{
        $artikull = mapArtikull();
        $artikull->id = $id;
        $repo = new Repository();
        $repo->updateArtikull($artikull);

        apiResponse($artikull, true, "Artikulli u ruajt me sukses");
    }
    catch(Exception $e) {
        apiResponse(NULL, false, $e->getMessage());
    }
}

function deleteArtikull(int $id){

    $repo = new Repository();
    $repo->deleteArtikull($id);

    apiResponse(NULL, true, "Artikulli u fshi me sukses");
}

//Ruaj Artikull
function indexPOST(?int $id){

    try{
        $artikull = mapArtikull();
        
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



function isApiCall(): bool{
    return substr( cleanPath(), 0, 4 ) === "/api";
}

function mapArtikull() : Artikull{
    $inputJSON = file_get_contents('php://input');
    $data = json_decode($inputJSON);
    

    $artikull = new Artikull();
    if (!IsNullOrEmptyString($data->emri)) {
        $artikull->emri = $data->emri;
    } else {
        throw new Exception("Emri duhet plotesuar");
    }
    if (!IsNullOrEmptyString($data->njesia)) {
        $artikull->njesia = $data->njesia;
    } else {
        throw new Exception("Njesia duhet plotesuar");
    }
    $artikull->dataSkadences = DateTime::createFromFormat('Y-m-d', $data->dataSkadences);
    if (!$artikull->dataSkadences) {
        throw new Exception("Data Skadences duhet plotesuar");
    }
    if (!IsNullOrEmptyString($data->cmimi)) {
        $artikull->cmimi = $data->cmimi;
    } else {
        throw new Exception("Cmimi duhet plotesuar");
    }

    if (!IsNullOrEmptyString($data->lloj)) {
        $artikull->lloj = $data->lloj;
    } else {
        throw new Exception("Lloj duhet plotesuar");
    }

    $artikull->kaTvsh = false;
    if (isset($data->kaTvsh)) {
        $artikull->kaTvsh = $data->kaTvsh;
    }
    

    if (!IsNullOrEmptyString($data->tipi)  && $data->tipi!= Tipi::None) {
        $artikull->tipi = $data->tipi;
    } else {
        throw new Exception("Tipi duhet plotesuar");
    }

    if (!IsNullOrEmptyString($data->barkod)) {
        $artikull->barkod = $data->barkod;
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

function isGet(): bool{
    return $_SERVER['REQUEST_METHOD'] === 'GET' ;
}
function isPost(): bool{
    return $_SERVER['REQUEST_METHOD'] === 'POST' ;
}

function isPut(): bool{
    return $_SERVER['REQUEST_METHOD'] === 'PUT' ;
}

function isDelete(): bool{
    return $_SERVER['REQUEST_METHOD'] === 'DELETE' ;
}

function IsNullOrEmptyString($str){
    return (!isset($str) || trim($str) === '');
}

function stringToBool($str ){
    return  $str == 'true';
}

function apiResponse($model, bool $succeeded, $message){
    header('Content-Type: application/json');
    $response = new ApiResponse($model, $succeeded, $message);
    //echo "<pre>". print_r($response)."</pre>";

    echo json_encode($response);
}