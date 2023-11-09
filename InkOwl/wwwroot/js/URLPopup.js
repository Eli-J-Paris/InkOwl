
document.addEventListener("DOMContentLoaded", function () {
    const openModalBtns = document.querySelectorAll(".btn-open");
    const modals = document.querySelectorAll(".modal");
    const overlay = document.querySelector(".overlay");
    const closeModalBtn = document.querySelector(".btn-close");

    // Open modal function
    const openModal = function (modalId) {
        const modal = document.getElementById("modal");
        modal.classList.remove("hidden");
        overlay.classList.remove("hidden");

    };

    // Close modal function
    const closeModal = function (modalId) {
        const modal = document.getElementById("modal");
        modal.classList.add("hidden");
        overlay.classList.add("hidden");
    };
    // close the modal when the close button and overlay is clicked
    closeModalBtn.addEventListener("click", closeModal);
    overlay.addEventListener("click", closeModal);

    // close modal when the Esc key is pressed
    document.addEventListener("keydown", function (e) {
        if (e.key === "Escape" && !modal.classList.contains("hidden")) {
            closeModal();
        }
    });


    // Add event listeners to open and close each modal
    openModalBtns.forEach((btn, index) => {
        btn.addEventListener("click", () => openModal(index));
    });

    modals.forEach((modal, index) => {
        modal.querySelector(".btn-close").addEventListener("click", () => closeModal(index));
    });
});

