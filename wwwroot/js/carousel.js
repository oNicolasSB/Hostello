const carouselSlide = document.querySelector('.carrossel_images')
const carouselImages = window.document.querySelectorAll('.carrossel_images img')

const btnAnterior = window.document.getElementById('btn_anterior')
const btnProximo = window.document.getElementById('btn_proximo')

let pos = 1;
const tam = carouselImages[0].clientWidth;

carouselSlide.style.transform = `translateX(${-tam * pos}px)`

btnProximo.addEventListener('click', ()=>{
    if (pos >= carouselImages.length-1 ) return;
    carouselSlide.style.transition = "transform 0.4s ease-in-out"
    pos++
    carouselSlide.style.transform = `translateX(${-tam * pos}px)`
})

btnAnterior.addEventListener('click', ()=>{
    if (pos <= 0 ) return;
    carouselSlide.style.transition = "transform 0.4s ease-in-out"
    pos--
    carouselSlide.style.transform = `translateX(${-tam * pos}px)`
})

carouselSlide.addEventListener('transitionend', ()=>{
    if(carouselImages[pos].id === "ultimo_copia"){
        carouselSlide.style.transition = "none"
        pos = carouselImages.length - 2;
        carouselSlide.style.transform = `translateX(${-tam * pos}px)`
    }
    else if(carouselImages[pos].id === "primeiro_copia"){
        carouselSlide.style.transition = "none"
        pos = carouselImages.length - pos;
        carouselSlide.style.transform = `translateX(${-tam * pos}px)`
    }
})