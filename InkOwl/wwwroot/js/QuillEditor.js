var toolbarOptions = [
    ['bold', 'italic', 'underline', 'strike'],        // toggled buttons
    ['blockquote', 'code-block'],

    [{ 'header': 1 }, { 'header': 2 }],               // custom button values
    [{ 'list': 'ordered' }, { 'list': 'bullet' }],
    [{ 'script': 'sub' }, { 'script': 'super' }],      // superscript/subscript
    [{ 'indent': '-1' }, { 'indent': '+1' }],          // outdent/indent
    [{ 'direction': 'rtl' }],                         // text direction

    [{ 'size': ['small', false, 'large', 'huge'] }],  // custom dropdown
    [{ 'header': [1, 2, 3, 4, 5, 6, false] }],

    [{ 'color': [] }, { 'background': [] }],          // dropdown with defaults from theme
    [{ 'font': [] }],
    [{ 'align': [] }],

    ['clean']                                         // remove formatting button
];



function updateForm() {
    var articleContent = quillArticle.root.innerHTML;
    document.getElementById('articleContent').value = articleContent;

    var noteContent = quillNote.root.innerHTML;
    document.getElementById('noteContent').value = noteContent;

    var articleTitle = document.getElementById('inputArticleTitle').value;
    document.getElementById('articleTitle').value = articleTitle;

    var noteTitle = document.getElementById('inputNoteTitle').value;
    document.getElementById('noteTitle').value = noteTitle;

    var urlContent = document.getElementById('inputUrl').value;
    document.getElementById('urlContent').value = urlContent;
}

setInterval(updateForm, 500);

var quillArticle = new Quill('#article-editor', {
    modules: {
        toolbar: toolbarOptions
    },
    placeholder: 'Compose an epic...',
    theme: 'snow'// 'bubble'
});
var quillNote = new Quill('#note-editor', {
    modules: {
        toolbar: toolbarOptions
    },
    placeholder: 'Compose an epic...',
    theme: 'snow' //'bubble'
});


// Function to perform auto-save
function autoSave() {
    // Get form data

    var formData = {
        articleContent: document.getElementById("articleContent").value,
        noteContent: document.getElementById("noteContent").value,
        articleTitle: document.getElementById("articleTitle").value,
        noteTitle: document.getElementById("noteTitle").value,
        urlContent: document.getElementById("urlContent").value
    };
    // Use AJAX to send data to the server
    $.ajax({
        url: '/savenest/@Model.Id/@Model.Articles[activeArticle].Id/@Model.Notes[activeNote].Id',
        type: 'POST',
        data: JSON.stringify(formData),
        //async: true,
        contentType: 'application/json',
        success: function (response) {
            // Handle success
            console.log('Auto-save successful');
        },
        error: function (error) {
            // Handle errors
            console.error('Auto-save failed', error);
        }
    });
}
// Set up interval for auto-save
setInterval(autoSave, 1000);


function toggleSidebar() {
    var sidebar = document.getElementById('sidebar');
    sidebar.classList.toggle('show');
}

function toggleDropdown(dropdownId) {
    var dropdown = document.getElementById(dropdownId);
    dropdown.classList.toggle('show');
}