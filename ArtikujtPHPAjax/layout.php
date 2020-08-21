<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">
    <link rel="stylesheet" href="/content/site.css"/>
    <title><?=Service::$title?></title>
</head>
<body>

<div class="navbar">
        
 
        <nav >
               
            <div class="navbar-collapse" id="navbarSupportedContent">
                <ul>

                    <li class="nav-item btn btn-primary btn-sm" onclick="onClickArtikullIRi()">
                        Artikull i ri
                    </li>
                    <button class="nav-item btn btn-success btn-sm" onclick="onClickRuaj()" id="ruajButton">
                              Ruaj
                    </button>
                    <li class="nav-item btn btn-danger btn-sm" onclick="onClickFshi()" id="fshiButton"> 
                        Fshi
                    </li>
                </ul>
            </div>
        </nav>


    </div>
    <div class=" body-content">
        
        <div class="side-bar">
             <?php require_once("kerko.php"); ?>
        </div>
        <div class="main">
            <?php  require_once("artikull.php"); ?>
        </div>
    
    </div>


    
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js" integrity="sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8shuf57BaghqFfPlYxofvL8/KUEfYiJOMMV+rV" crossorigin="anonymous"></script>
    <script
  src="https://code.jquery.com/jquery-3.5.1.min.js"
  integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0="
  crossorigin="anonymous"></script>
  <script src="/content/site.js"></script>

</body>
</html>