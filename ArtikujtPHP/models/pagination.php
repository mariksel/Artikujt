<?php


class Pagination{
    public $models = array();
    public int $numberOfPages;
    public $pages = array();

    function __construct($_models, int $_numberOfPages, int $currentPgeIndex)
    {
        $this->models = $_models;
        $this->numberOfPages = $_numberOfPages;

        for ($i=1; $i <= $_numberOfPages; $i++) { 
            $page = new Page($i, $currentPgeIndex == $i);
           array_push($this->pages, $page);
        }
    }
    
}

class Page{
    public int $index;
    public bool $isActive;

    function __construct(int $_index, bool $_isActive){
        $this->index = $_index;
        $this->isActive = $_isActive;
    }
}