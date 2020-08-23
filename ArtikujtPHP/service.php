<?php
require_once 'models/artikull.php';

class Service{

    
    public static string $title = '';
    public static ?string $success = null;
    public static ?string $error = null;
    public static string $page = '';
    public static Artikull $artikull;
    public static Pagination $pagination;
    public static string $dilButton = "Dil";

    public static function init(){
        
    }

    function __construct()
    {
        self::createNewArtikull();
    }

    public static function createNewArtikull(){
        self::$artikull = new Artikull();
        self::$artikull->isNew = TRUE;
        self::$artikull->id = 0;
        self::$artikull->emri = '';
        self::$artikull->njesia = '';
        self::$artikull->dataSkadences = new DateTime();
        self::$artikull->cmimi = 0;
        self::$artikull->lloj = '';
        self::$artikull->kaTvsh = false;
        self::$artikull->tipi = Tipi::None;
        self::$artikull->barkod = '';
    }
}