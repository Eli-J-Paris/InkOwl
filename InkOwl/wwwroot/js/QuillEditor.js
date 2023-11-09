
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



document.querySelector('form').addEventListener('submit', function (e) {
    e.preventDefault();
    var articleContent = quillArticle.root.innerHTML;
    var noteContent = quillNote.root.innerHTML;
    document.getElementById('articleContent').value = articleContent;
    document.getElementById('noteContent').value = noteContent;
    this.submit(); // Submit the form with the editor content
});

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
    theme: 'snow' /*'bubble'*/
});


