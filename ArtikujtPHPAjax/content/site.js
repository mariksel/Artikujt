let artikullForm = document.getElementById("artikullForm");
let ruajButtonElm = document.getElementById("ruajButton");
let fshiButtonElm = document.getElementById("fshiButton");

function onClickArtikullIRi(){
    console.log("artikull i ri");
    createNewArtikull();
    reset();
    clearMessage();
}

function hideFshiButton(){
    fshiButtonElm.style.display = "none";
}

function onClickRuaj(){
    ruajButtonElm.disabled = true;

 
    if(artikullForm.reportValidity()){
        if(artikull.isNew){
            createArtikull();
        } else {
            updateArtikull();
        }
    } else {
        clearMessage();
        ruajButtonElm.disabled = false;
    }

}

function createArtikull(){
    $.ajax({
        url: `api/artikull`,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(artikull),
        success: function(result) {
            if(result.succeeded){
                showSuccess(result.message);
                loadPage(currentIndex);
                createNewArtikull();
                reset();
            } else {
                showError(result.message);
            }
            ruajButtonElm.disabled = false;
        },
        error: function (xhr, ajaxOptions, thrownError) {
          alert(xhr.status);
          alert(thrownError);
          ruajButtonElm.disabled = false;
        }
    });
}

function updateArtikull(){
    $.ajax({
        url: `api/artikull?id=${artikull.id}`,
        type: 'PUT',
        contentType: 'application/json',
        data: JSON.stringify(artikull),
        success: function(result) {
            if(result.succeeded){
                showSuccess(result.message);
                loadPage(currentIndex);
            } else {
                showError(result.message);
            }
            ruajButtonElm.disabled = false;
            createNewArtikull();
            reset();
        },
        error: function (xhr, ajaxOptions, thrownError) {
          alert(xhr.status);
          alert(thrownError);
          ruajButtonElm.disabled = false;
        }
    });
}

function onClickFshi(){
    console.log("fshi");
    $.ajax({
        url: `api/artikull?id=${artikull.id}`,
        type: 'DELETE',
        success: function(result) {
            if(result.succeeded){
                createNewArtikull();
                reset();
                showSuccess(result.message);
                loadPage(currentIndex);
            } else {
                showError(result.message);
            }
        }
    });

}

let currentIndex = 1;

class Artikull{
    isNew;
    id;
    emri;
    njesia;
    dataSkadences;
    //dataSkadencesText;
    cmimi;
    lloj;
    kaTvsh;
    tipi;
    barkod;
}

let artikull = new Artikull();

function createNewArtikull(){
    artikull = new Artikull();
    artikull.isNew = true;
    artikull.emri = "";
    artikull.njesia = "";
    artikull.dataSkadences = "";
    artikull.cmimi = "";
    artikull.lloj = "";
    artikull.kaTvsh = false;
    artikull.tipi = "";
    artikull.barkod = "";
    
    hideFshiButton();
}

createNewArtikull();

let inputEmri = document.getElementById("inputEmri");
let inputNjesia = document.getElementById("inputNjesia");
let inputDataSkadences = document.getElementById("inputDataSkadences");
let inputCmimi = document.getElementById("inputCmimi");
let inputLlojImportuar = document.getElementById("inputLlojImportuar");
let inputLlojVendi = document.getElementById("inputLlojVendi");
let inputKaTvsh = document.getElementById("inputKaTvsh");
let selectTipi = document.getElementById("selectTipi");
let inputBarkod = document.getElementById("inputBarkod");

let kerkoList = document.getElementById("kerkoList");
let paginationList = document.getElementById("paginationList");
let messageElm = document.getElementById("message");

function onChangeEmri(){
    artikull.emri = inputEmri.value;
    console.log(inputEmri.value);

}

function onChangeNjesia(){
    artikull.njesia = inputNjesia.value;
    console.log(inputNjesia.value);
    
}
function onChangeDataSkadences(){
    artikull.dataSkadences = inputDataSkadences.value;
    console.log(inputDataSkadences.value);
    
}
function onChangeCmimi(){
    artikull.cmimi = inputCmimi.value;
    console.log(inputCmimi.value);
    
}
function onChangeLlojImportuar(){
    artikull.lloj = inputLlojImportuar.value;
    console.log(inputLlojImportuar.value);
    
}
function onChangeLlojVendi(){
    artikull.lloj = inputLlojVendi.value;
    console.log(inputLlojVendi.value);
    
}

function onChangeKaTvsh(){
    artikull.kaTvsh = inputKaTvsh.checked;
    console.log(inputKaTvsh.checked);
    
}

function onChangeTipi(){
    artikull.tipi = selectTipi.value;
    console.log(selectTipi.value);
    
}
function onChangeBarkod(){
    artikull.barkod = inputBarkod.value;
    console.log(inputBarkod.value);
}

function reset(){
    if(artikull.isNew){
        inputEmri.value = null;
        inputNjesia.value = null;
        inputDataSkadences.value = null;
        inputCmimi.value = null;
        inputLlojImportuar.checked = false;
        inputLlojVendi.checked = false;
        inputKaTvsh.checked = false;
        selectTipi.value = "none";
        inputBarkod.value = null;
    }
    else{
        inputEmri.value = artikull.emri;
        inputNjesia.value = artikull.njesia;
        inputDataSkadences.value = artikull.dataSkadences;
        inputCmimi.value = artikull.cmimi;
        inputLlojImportuar.checked = artikull.lloj == "I";
        inputLlojVendi.checked = artikull.lloj == "V";
        inputKaTvsh.checked = artikull.kaTvsh;
        selectTipi.value = artikull.tipi;
        inputBarkod.value = artikull.barkod;
    }
    
}

function loadPage(index){
    currentIndex = index;
    $.get('/api/artikujt?index=1',  
        {index: index},
      function (data, textStatus, jqXHR) {  // success callback
          console.log(data.model);
          generateKerkoItems(data.model.models);
          generatePages(data.model.pages);
    });
}

loadPage(1);

function generateKerkoItems(artikujt) {
    kerkoList.innerHTML = "";
    artikujt.forEach(artikull => {
        item = generateKerkoItem(artikull);
        kerkoList.appendChild(item);
    });
}

function generateKerkoItem(artikull){
    let ul = document.createElement("ul");
    ul.className = "list-group";
    ul.onclick = function(){  
        loadArtikull(artikull.id);
        clearMessage();
        fshiButtonElm.style.display = "inline-block";
     };


    let a = document.createElement("a");
    a.className = "card";
    let li = document.createElement("li");
    li.className = "list-group-item list-group-item-action";
    
    let span1 = document.createElement("span");
    span1.className = "badge badge-secondary badge-pill";
    span1.innerHTML = artikull.id;
    let span2 = document.createElement("span");
    span2.className = "mx-5 h5";
    span2.innerHTML = artikull.emri;
    let span3 = document.createElement("span");
    span3.className = "badge badge-primary  badge-pill float-right";
    span3.innerHTML = artikull.cmimi;

    ul.appendChild(a);
    a.appendChild(li);
    li.appendChild(span1);
    li.appendChild(span2);
    li.appendChild(span3);

    return ul;
}

function generatePages(pages){
    paginationList.innerHTML = "";
    pages.forEach(page => {
        item = generatePage(page);
        paginationList.appendChild(item);
    });
}

function generatePage(page){
    let li = document.createElement("li");
    li.className = page.isActive ? "page-item active" : "page-item";
    let a = document.createElement("a");
    a.className = "page-link";
    a.innerHTML = page.index;
    let span = document.createElement("span");
    span.className = "sr-only";
    span.innerHTML = "(current)";

    li.appendChild(a);
    if(page.isActive){
        a.appendChild(span);
    }

    li.onclick = function(){  
        loadPage(page.index);
        clearMessage();
    };
    
    return li;
}

function loadArtikull(id){
    $.get('/api/artikull',  
        {id: id},
      function (data, textStatus, jqXHR) {  // success callback
          if(data.succeeded){
            artikull = new Artikull();
            artikull.id = data.model.id;
            artikull.emri = data.model.emri;
            artikull.njesia = data.model.njesia;
            artikull.dataSkadences = data.model.dataSkadencesText;
            artikull.cmimi = data.model.cmimi;
            artikull.lloj = data.model.lloj;
            artikull.kaTvsh = data.model.kaTvsh;
            artikull.tipi = data.model.tipi;
            artikull.barkod = data.model.barkod;
            reset();
          console.log(data.model);

          } else{
              console.log(data);
          }
    });
}

function showError(message){
    messageElm.innerHTML = "";
    let div= document.createElement("div");
    div.className = "alert alert-danger";
    div.innerHTML = message;

    messageElm.appendChild(div);
}

function showSuccess(message){
    messageElm.innerHTML = "";
    let div= document.createElement("div");
    div.className = "alert alert-success";
    div.innerHTML = message;

    messageElm.appendChild(div);
}

function clearMessage(){
    messageElm.innerHTML = "";
}
