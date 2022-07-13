let formusuario = document.querySelector("div#ent_usuario")
let formhoteleiro = document.querySelector("div#ent_hoteleiro")
let botaousuario = document.querySelector("input#opcusuario")
let botaohoteleiro = document.querySelector("input#opchoteleiro")

function alterarusuario(){

    
    formhoteleiro.style.display = 'none'
    formusuario.style.display = 'block'
    botaousuario.style.backgroundColor = "#A1952B"
    botaohoteleiro.style.backgroundColor = "#FFE713"
    botaousuario.style.boxShadow = "0px 0px 3px  rgba(0, 0, 0, 0.39)"
    botaohoteleiro.style.boxShadow = "0px 3px 5px  rgba(0, 0, 0, 0.8)"
    botaousuario.style.color = "white"
    botaohoteleiro.style.color = "black"

}

function alterarhoteleiro(){


    formhoteleiro.style.display = 'block'
    formusuario.style.display = 'none'
    botaousuario.style.backgroundColor = "#FFE713"
    botaohoteleiro.style.backgroundColor = "#A1952B"
    botaohoteleiro.style.boxShadow = "0px 0px 3px  rgba(0, 0, 0, 0.39)"
    botaousuario.style.boxShadow = "0px 3px 5px rgba(0, 0, 0, 1)"
    botaousuario.style.color = "black"
    botaohoteleiro.style.color = "white"

}
