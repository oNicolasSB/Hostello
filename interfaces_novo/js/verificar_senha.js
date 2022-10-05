let botao = window.document.getElementById('proximo')
botao.style.pointerEvents = 'none';
botao.style.backgroundColor = "#0d3d57"

function verificar()
{
    let senha = window.document.getElementById('password').value
    let confirmar = window.document.getElementById('confirm').value
    let mensagem = window.document.getElementById('message')
    
    if((senha == "") & (confirmar == "")){
        mensagem.innerHTML = ""
        botao.style.pointerEvents = 'none'
        botao.style.backgroundColor = "#0d3d57"
    } else if(senha == confirmar){
        mensagem.innerHTML = "Senhas conferem"
        mensagem.style.color = "green"
        botao.style.pointerEvents = 'auto'
        botao.style ='inital' 
    } else {
        mensagem.innerHTML = "Senhas não conferem"
        mensagem.style.color = "red"
        botao.style.pointerEvents = 'none'
        botao.style.backgroundColor = "#0d3d57"
    }
}
