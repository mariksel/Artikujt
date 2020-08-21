<?php
require_once 'lib/rb.php';
require_once 'models/pagination.php';

class Repository{
    public const ARTIKUJT = 'artikujt';
    public const DATE_FORMAT = 'Y-m-d H:i:s';

    public static bool $isInitialized = false;

    function __construct(){
        if(!Repository::$isInitialized){
            R::setup('mysql:host=localhost;dbname=softexpres', 'root', '');
            R::freeze(1);
            Repository::$isInitialized = true;
        }
        
    }

    function getArtikull(int $id) {
        $entity = R::load(Repository::ARTIKUJT, $id);

        if($entity['id'] == 0){
            return NULL;
        }

        $artikull = new Artikull();
        $artikull->isNew = false;
        $artikull->id = $entity['id'];
        $artikull->emri = $entity['emri'];
        $artikull->njesia = $entity['njesia'];
        $artikull->dataSkadences =  DateTime::createFromFormat(Repository::DATE_FORMAT, $entity['data_skadences']);
        $artikull->dataSkadencesText = $artikull->dataSkadences->format('Y-m-d');
        $artikull->cmimi = $entity['cmimi'];
        $artikull->lloj = $entity['lloj'];
        $artikull->kaTvsh = $entity['ka_tvsh'];
        $artikull->tipi = $entity['tipi'];
        $artikull->barkod = $entity['barkod'];

        return $artikull;
    }

    function addArtikull(Artikull $artikull){
        
        $entity = R::dispense(Repository::ARTIKUJT);


        $entity->emri = $artikull->emri;
        $entity->njesia = $artikull->njesia;
        $entity->data_skadences = $artikull->dataSkadences->format(Repository::DATE_FORMAT);
        $entity->cmimi = $artikull->cmimi;
        $entity->lloj = $artikull->lloj;
        $entity->ka_tvsh = $artikull->kaTvsh;
        $entity->tipi = $artikull->tipi;
        $entity->barkod = $artikull->barkod;


        $artikull->id = R::store($entity);
    }

    function updateArtikull(Artikull $artikull){
        $entity = R::load(Repository::ARTIKUJT, $artikull->id);


        $entity->emri = $artikull->emri;
        $entity->njesia = $artikull->njesia;
        $entity->data_skadences = $artikull->dataSkadences->format(Repository::DATE_FORMAT);
        $entity->cmimi = $artikull->cmimi;
        $entity->lloj = $artikull->lloj;
        $entity->ka_tvsh = $artikull->kaTvsh;
        $entity->tipi = $artikull->tipi;
        $entity->barkod = $artikull->barkod;

        R::store($entity);
    }

    function deleteArtikull(int $id){
        $entity = R::load(Repository::ARTIKUJT, $id);

        R::trash($entity);
    }

    function artikujt(int $pageIndex): Pagination{

        $pageSize = 10;
        $offset = ($pageIndex - 1) * $pageSize;

        $query = 'SELECT * FROM '.Repository::ARTIKUJT.' ORDER BY Id DESC  LIMIT ?,?';
        $entityList = R::getAll($query, [$offset, $pageSize]);

        $artikujt = array();
        
        foreach($entityList as $entity){

            $artikull = new Artikull();
            $artikull->id = $entity['id'];
            $artikull->emri = $entity['emri'];
            $artikull->njesia = $entity['njesia'];
            $artikull->dataSkadences =  DateTime::createFromFormat(Repository::DATE_FORMAT, $entity['data_skadences']);
            $artikull->dataSkadencesText = $artikull->dataSkadences->format('Y-m-d');
            $artikull->cmimi = $entity['cmimi'];
            $artikull->lloj = $entity['lloj'];
            $artikull->kaTvsh = $entity['ka_tvsh'];
            $artikull->tipi = $entity['tipi'];
            $artikull->barkod = $entity['barkod'];

            array_push($artikujt, $artikull);
            
        }

        $result = R::getAll('SELECT COUNT(*) AS count FROM artikujt');
        $totalCount = $result[0]['count'];
        $numerOfPages = ceil($totalCount/$pageSize);



        $pageintion = new Pagination($artikujt, $numerOfPages, $pageIndex);

        
        return $pageintion;
    }
}