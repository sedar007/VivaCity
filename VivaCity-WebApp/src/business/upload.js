document.addEventListener('DOMContentLoaded', function() {

    const form = document.getElementById('uploadForm');
    form.addEventListener('submit', async function (event) {
        event.preventDefault();

        const fileInput = document.getElementById('fileInput');
        const file = fileInput.files[0];

        const formData = new FormData();
        formData.append('file', file);

        const response = await fetch('/api/upload/upload', {
            method: 'POST',
            body: formData
        });

        const result = await response.json();
        console.log(result);
    });

});