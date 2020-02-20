
var post = document.getElementById('textEditor');

post.addEventListener('input', function (e) {
    var val = post.value;
    if (val == null || val.trim() == "") {
        document.querySelector('.mypost-footer_publish-btn').classList.remove('mypost-footer_publishEnable');
        document.querySelector('.mypost-footer_publish-btn').classList.add('mypost-footer_publishDisable');
        console.log("dakhlt")
    }
    else {
        document.querySelector('.mypost-footer_publish-btn').classList.remove('mypost-footer_publishDisable');
        document.querySelector('.mypost-footer_publish-btn').classList.add('mypost-footer_publishEnable');
        console.log("dakhlt2")
    }
});
var addHashtag = document.querySelector('.mypost-hashtag');
addHashtag.addEventListener('click', function (e) {
    document.getElementById('textEditor').value += "#";
});

var onAddBtn = function (e) {
    //1.get Data from input fields
    var inputComment = document.querySelector(".inputComment").value;
    document.querySelector('.comment-sec').style.display = 'block';
    document.querySelector('.comment--text').innerHTML += inputComment;
    console.log(inputComment);
    console.log(onAddBtn);

};

document.addEventListener('keypress', function (event) {
    if (event.keyCode === 13 || event.which === 13) {
        onAddBtn(event);
    }
});

document.querySelector('.comment-like').addEventListener('click', function () {
    document.querySelector('.comment-like').classList.toggle('text-primary');
    document.querySelector('.likes-no').classList.toggle('pr-2');
    document.querySelector('.likes-no').classList.toggle('d-inline');

});

document.querySelector('.option-click').addEventListener('click', function () {
    document.querySelector('.comment-options').classList.toggle('d-block');
});

$('#myModal').on('shown.bs.modal', function () {
    $('#myInput').trigger('focus')
})

//reactions popoover  
$('[data-toggle="popover"]').popover({
    trigger: 'manual',
    html: true,
    animation: false,
    viewport: '.container'
}).on('mouseenter', function () {
    var self = this;
    jQuery(this).popover("show");
    jQuery(".popover").on('mouseleave', function () {
        jQuery(self).popover('hide');
    });
}).on('mouseleave', function () {
    var self = this;
    setTimeout(function () {
        if (!jQuery('.popover:hover').length) {
            jQuery(self).popover('hide');
        }
    }, 600);
});
$('body').on('click', '.popover', function (target) {
    // code here
    if (target.target.id !== "") {
        $('.reaction-sign').remove();
        $('.reactions-container').prepend('<i class="' + target.target.className + 'container__Sign reaction-sign"></i>');
    }
});