let divusuario = document.querySelector("div#ent_usuario")
let divhoteleiro = document.querySelector("div#ent_hoteleiro")
let botaousuario = document.querySelector("input#opcusuario")
let botaohoteleiro = document.querySelector("input#opchoteleiro")

function alterarusuario(){

    
    divhoteleiro.style.display = 'none'
    divusuario.style.display = 'block'
    botaousuario.style.backgroundColor = "#A1952B"
    botaohoteleiro.style.backgroundColor = "#fec106"
    botaousuario.style.color = "white"
    botaohoteleiro.style.color = "white"

}

function alterarhoteleiro(){

    divusuario.style.display = 'none'
    divhoteleiro.style.display = 'block'
    botaousuario.style.backgroundColor = "#fec106"
    botaohoteleiro.style.backgroundColor = "#A1952B"
    botaousuario.style.color = "white"
    botaohoteleiro.style.color = "white"

}
