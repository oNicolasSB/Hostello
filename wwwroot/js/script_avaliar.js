let estrela1 = document.getElementById("estrela1")
let estrela2 = document.getElementById("estrela2")
let estrela3 = document.getElementById("estrela3")
let estrela4 = document.getElementById("estrela4")
let estrela5 = document.getElementById("estrela5")
let avaliacao = document.querySelector("#NotaAvaliacao")

document.getElementsByTagName("body")[0].addEventListener("onload", avaliar3());

function avaliar1(){
    estrela1.className = "bi bi-star-fill"
    estrela2.className = "bi bi-star"
    estrela3.className = "bi bi-star"
    estrela4.className = "bi bi-star"
    estrela5.className = "bi bi-star"
    avaliacao.setAttribute('value', 1)
    console.log(avaliacao)
}

function avaliar2(){
    estrela1.className = "bi bi-star-fill"
    estrela2.className = "bi bi-star-fill"
    estrela3.className = "bi bi-star"
    estrela4.className = "bi bi-star"
    estrela5.className = "bi bi-star"
    avaliacao.setAttribute('value', 2)
    console.log(avaliacao)
}

function avaliar3(){
    estrela1.className = "bi bi-star-fill"
    estrela2.className = "bi bi-star-fill"
    estrela3.className = "bi bi-star-fill"
    estrela4.className = "bi bi-star"
    estrela5.className = "bi bi-star"
    avaliacao.setAttribute('value', 3)
    console.log(avaliacao)
}

function avaliar4(){
    estrela1.className = "bi bi-star-fill"
    estrela2.className = "bi bi-star-fill"
    estrela3.className = "bi bi-star-fill"
    estrela4.className = "bi bi-star-fill"
    estrela5.className = "bi bi-star"
    avaliacao.setAttribute('value', 4)
    console.log(avaliacao)
}

function avaliar5(){
    estrela1.className = "bi bi-star-fill"
    estrela2.className = "bi bi-star-fill"
    estrela3.className = "bi bi-star-fill"
    estrela4.className = "bi bi-star-fill"
    estrela5.className = "bi bi-star-fill"
    avaliacao.setAttribute('value', 5)
    console.log(avaliacao)
}
