let responsavel = window.document.getElementById("responsavel");
let endereco = window.document.getElementById("endereco");

window.onload(voltar());

function avancar(){
    responsavel.style.display = "none";
    endereco.style.display = "block";
}

function voltar(){
    responsavel.style.display = "block";
    endereco.style.display = "none";
}