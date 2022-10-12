let cartao = window.document.getElementById("divcartao")
let pix = window.document.getElementById("divpix")
let boleto = window.document.getElementById("divboleto")

function altcartao(){
    cartao.style.display = 'block'
    pix.style.display = 'none'
    boleto.style.display = 'none'
}

function altpix(){
    cartao.style.display = 'none'
    pix.style.display = 'block'
    boleto.style.display = 'none'
}

function altboleto(){
    cartao.style.display = 'none'
    pix.style.display = 'none'
    boleto.style.display = 'block'
}
