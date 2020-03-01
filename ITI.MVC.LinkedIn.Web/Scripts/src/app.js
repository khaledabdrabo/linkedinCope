
document.querySelector('.search input').addEventListener('click',function(e){
    document.querySelector('.search1').classList.remove('hide'); 
    document.querySelector('.search1>input').focus();
});

document.querySelector('.search1 input').addEventListener('focusout',function(e){ 
    document.querySelector('.search1').classList.add('hide');   
});