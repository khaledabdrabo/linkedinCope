let postsContainer = document.getElementById("postsContainer");

postsContainer.addEventListener("click", onPostsContainerClick);

// Handle like

function onPostsContainerClick(e) {

    if (!e.target) {
        return;
    }

    if (e.target.classList.contains("post-like-btn")) {

        toggleLike(e.target, "post");
    }

    if (e.target.classList.contains("like-icon")) {

        toggleLike(e.target.parentElement, "post");
    }

    if (e.target.classList.contains("comment-like")) {

        toggleLike(e.target, "comment");
    }
}

async function toggleLike(btn, entityType) {

    let urlParams = `id=${btn.id}&entityType=${entityType}`;
    let response = await fetch(`/Feed/ToggleLike/?${urlParams}`, { method: "POST" });
    let success = await response.text();

    if (success.toLowerCase() === "true") {

        switch (entityType) {

            case "post":
                document.getElementById(`likeIcon${btn.id}`).classList.toggle("text-primary");
                break;

            case "comment":
                btn.classList.toggle("text-primary");
                break;
        }
    }
}
