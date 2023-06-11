function GetAll() {
    axios.get("https://localhost:7224/api/Diary")
        .then(res => {
            let data = res.data
            document.getElementById("tabloBody").innerHTML = ""

            data.forEach(element => {
                console.log(element);
                let trElement = document.createElement("tr")
                let thElement1 = document.createElement("th")
                let thElement2 = document.createElement("th")
                let thElement3 = document.createElement("th")

                

                thElement1.innerHTML = element.title
                thElement2.innerHTML = element.body 
                
                
                thElement3.innerHTML = `<button onclick="DeleteData(${element.id})" >Delete</button>`;
                console.log(thElement3)

                trElement.appendChild(thElement1)   
                trElement.appendChild(thElement2)
                trElement.appendChild(thElement3)
                document.getElementById("tabloBody").appendChild(trElement)

            });
        })
}


// function addNew(){
//     let title = document.getElementById("titlebox").value
//     let text = document.getElementById("textbox").value

//     let newDiary = {
//         companyName:title,
//         contactName :text
//     }
//     axios.post("https://northwind.vercel.app/api/categories",newDiary)
//     .then (res => {
//         console.log(res)
//         alert("Success")
//         GetAll()

//     })}




function add() {

    let title = document.getElementById('titlebox').value;
    let body = document.getElementById('textbox').value

    let newDiary = {
        title : title,
        body : body
    }


    axios.post('https://localhost:7224/api/Diary', newDiary)
        .then(res => {
            console.log('Response', res);
            alert('Ekleme işlemi başarılı')
        })

}




// function DeleteData(id) {
    
//     axios.delete('https://localhost:7224/api/Diary/'+id)
//     .then(res => {
//         alert("Success")
//         document.getElementById("tabloBody").innerHTML=""
//         GetAll()



//     })

// }


GetAll()