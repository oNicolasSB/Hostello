function verificar()
{
    let senha = window.document.getElementById('password').value
    let confirmar = window.document.getElementById('confirm').value
    let mensagem = window.document.getElementById('message')
    
    if((senha == "") & (confirmar == "")){
        mensagem.innerHTML = ""
    } else if(senha == confirmar){
        mensagem.innerHTML = "Senhas conferem"
        mensagem.style.color = "green"
    } else {
        mensagem.innerHTML = "Senhas não conferem"
        mensagem.style.color = "red"
    }
}
