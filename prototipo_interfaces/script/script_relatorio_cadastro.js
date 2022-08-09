let tableusuario = document.querySelector("div#tabelausuario")
let tablehoteleiro = document.querySelector("div#tabelahoteleiro")
let botaousuario = document.querySelector("input#opcusuario")
let botaohoteleiro = document.querySelector("input#opchoteleiro")

function alterarusuario(){

    
    tablehoteleiro.style.display = 'none'
    tableusuario.style.display = 'block'
    botaousuario.style.backgroundColor = "#A1952B"
    botaohoteleiro.style.backgroundColor = "#FFE713"
    botaousuario.style.boxShadow = "0px 0px 3px  rgba(0, 0, 0, 0.39)"
    botaohoteleiro.style.boxShadow = "0px 3px 5px  rgba(0, 0, 0, 0.8)"
    botaousuario.style.color = "white"
    botaohoteleiro.style.color = "black"

}

function alterarhoteleiro(){


    tablehoteleiro.style.display = 'block'
    tableusuario.style.display = 'none'
    botaousuario.style.backgroundColor = "#FFE713"
    botaohoteleiro.style.backgroundColor = "#A1952B"
    botaohoteleiro.style.boxShadow = "0px 0px 3px  rgba(0, 0, 0, 0.39)"
    botaousuario.style.boxShadow = "0px 3px 5px rgba(0, 0, 0, 1)"
    botaousuario.style.color = "black"
    botaohoteleiro.style.color = "white"

}
