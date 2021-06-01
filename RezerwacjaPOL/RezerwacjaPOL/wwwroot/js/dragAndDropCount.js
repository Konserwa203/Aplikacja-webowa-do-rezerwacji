
    let inputFile = document.getElementById('drop-zone');
    let fileNmeField = document.getElementById('howMany');
    inputFile.addEventListener('change', function (event) {
        let uploadedFileNames = event.target.files.length;
        let names = event.target.files;
        var files = "";
        var textToRead = "";
        for (var i = 0; i < uploadedFileNames; i++) {
            files = files.concat(names[i].name, ", ");
          
        }
        
        fileNmeField.textContent = "Pliki do przesłania: " + files;
    })


