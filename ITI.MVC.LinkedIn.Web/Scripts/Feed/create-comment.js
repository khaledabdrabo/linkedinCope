let commentFailureMsg = document.getElementById("commentFailureMsg");

function onCommentSuccess(response) {

    if (response === "false") {

        onCommentFailure();
    }
}

function onCommentFailure() {

    commentFailureMsg.textContent = "An error encountered while posting the comment";
}