function GetAll() {
    axios.get("https://localhost:7224/api/Diary")
        .then(res => {
            let data = res.data
            document.getElementById("tabloBody").innerHTML = ""

            data.reverse().forEach(element => {
                console.log(element);
                let trElement = document.createElement("tr")
                let thElement1 = document.createElement("th")
                let thElement2 = document.createElement("th")
                let thElement3 = document.createElement("th")



                thElement1.innerHTML = element.title
                thElement2.innerHTML = element.body


                thElement3.innerHTML = `<div id="buttonlarDiv">
                <button onclick="Update(${element.id})" id="buttonlarUpdate" ><i class="fas fa-wrench fa-xl"></i></button> <button onclick="DeleteData(${element.id})" id="buttonlarDelete" ><i class="far fa-trash-alt fa-xl"></i></button>
              
              </div>`;
                console.log(thElement3)

                trElement.appendChild(thElement1)
                trElement.appendChild(thElement2)
                trElement.appendChild(thElement3)
                document.getElementById("tabloBody").appendChild(trElement)

            });
        })
}

// thElement3.innerHTML = `<button onclick="Update(${element.id})" id="buttonlarUpdate" >Update</button> <button onclick="DeleteData(${element.id})" id="buttonlarDelete" ><i class="far fa-trash-alt fa-xl"></i></button>`;
// console.log(thElement3)




function create() {

    let title = document.getElementById('titlebox').value.trim();
    let body = document.getElementById('textbox').value.trim()

    if (title !="" && body!="") {
       
        let newDiary = {
            title: title,
            body: body
        }
    
    
        axios.post('https://localhost:7224/api/Diary/create', newDiary)
            .then(res => {
                console.log('Response', res);
                document.getElementById("tabloBody").innerHTML = ""
                GetAll()
                alert('New note Succesfully added!')
            })

    }

    if(title =="" && body!=""){alert("Title is empty!! ")}
    if(title !="" && body==""){alert("Text is empty!!")}
   
    



}




function DeleteData(id) {

    axios.delete('https://localhost:7224/api/Diary/delete/' + id)
        .then(res => {
            alert("Success")
            document.getElementById("tabloBody").innerHTML = ""
            GetAll()



        })

}

function Update(id) {

    let newTitle = document.getElementById('titlebox').value;
    let newBody = document.getElementById('textbox').value;


    axios.put("https://localhost:7224/api/Diary/update/" + id, { title: newTitle, body: newBody })
        .then(res => {
            alert("Success")
            document.getElementById("tabloBody").innerHTML = ""
            GetAll()


        })




}


GetAll()