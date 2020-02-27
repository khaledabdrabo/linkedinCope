let postModal = document.getElementById("post"),
    postFailureMsg = document.getElementById("postFailureMsg");

function onPostSuccess(response) {

    if (response === "success") {

        postModal.classList.remove("show");
    }

    else {
        onPostFailure();
    }
}

function onPostFailure() {

    postFailureMsg.textContent = "An error encountered while creating a post";
    postFailureMsg.classList.remove("hide");
}