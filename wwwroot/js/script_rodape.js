window.onload = ajustar();
window.addEventListener('resize', ajustar);

function ajustar () {
    let conteudo = window.document.body.offsetHeight;
    let rodape = window.document.getElementById("rodape");
    let janela = window.innerHeight;
    
    if (conteudo < janela){
        var margem = rodape.style.marginTop
        margem = (janela - conteudo) + "px";
        rodape.style.cssText = 'margin-top:'+margem+' !important';
    }
    
    // console.log("conteudo: " + conteudo);
    // console.log("rodape: " + rodape.offsetHeight);
    // console.log("janela: " + janela);
    // console.log("margem: " + margem);
    
}

