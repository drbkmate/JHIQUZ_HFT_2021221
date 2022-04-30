let cars = [];
let connection = null;
let carIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    //kapcsolódik
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:51322/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    //feliratkoz
    connection.on("CarCreated", (user, message) => {
        getdata();
    });
    connection.on("CarDeleted", (user, message) => {
        getdata();
    });
    connection.on("CarUpdated", (user, message) => {
        getdata();
    });
    //elindít
    connection.onclose(async () => {
        await start();
    });
    start();
}
async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:51322/car')
        .then(x => x.json())
        .then(y => {
            cars = y
            //console.log(cars);
            display();
        });
}

function display() {
    document.getElementById('resultArea').innerHTML = "";
    cars.forEach(t => {
        document.getElementById('resultArea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.brand.name + "</td><td>" + t.model + "</td><td>" + t.basePrice + "</td><td>" + t.engine.ccm + "</td><td>" + `<button type="button" class="btn btn-danger" onclick="remove(${t.id})">Delete</button>` + `<button type="button" class="btn mx-1 btn-warning" onclick="showupdate(${t.id})">Update</button>` + "</td></tr>";
        console.log(t.model)
    });
}

function create() {
    let model = document.getElementById('model').value;
    let brandid = document.getElementById('brandid').value;

    let baseprice = document.getElementById('baseprice').value;
    let engineid = document.getElementById('engineid').value;
    fetch('http://localhost:51322/car', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify({
            model: model,
            brandId: brandid,
            engineId: engineid,
            basePrice: baseprice
            }),
    })
    .then(response => response)
    .then(data => { console.log('Success: ', data); getdata(); })
    .catch((error) => { console.error('Error: ', error); });

}

function remove(id) {
    fetch('http://localhost:51322/car/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => { console.log('Success: ', data); getdata(); })
        .catch((error) => { console.error('Error: ', error); });

}

function showupdate(id) {
    document.getElementById('model_toupdate').value = cars.find(t => t['id'] == id)['model'];
    document.getElementById('baseprice_toupdate').value = cars.find(t => t['id'] == id)['basePrice'];
    document.getElementById('engineid_toupdate').value = cars.find(t => t['id'] == id)['engineId'];

    document.getElementById('updateformdiv').className = 'my-5';

    carIdToUpdate = id;
    console.log("actoridtoupdate: " + actorIdToUpdate);
}

function update() {
    document.getElementById('updateformdiv').className = 'my-5 d-none'
    let model = document.getElementById('model_toupdate').value;
    let brandid = document.getElementById('brandid_toupdate').value;
    let baseprice = document.getElementById('baseprice_toupdate').value;
    let engineid = document.getElementById('engineid_toupdate').value;

    fetch('http://localhost:51322/car', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify({
            Id: carIdToUpdate,
            model: model,
            brandId: brandid,
            engineId: engineid,
            basePrice: baseprice
        }),
    })
        .then(response => response)
        .then(data => { console.log('Success: ', data); getdata(); })
        .catch((error) => { console.error('Error: ', error); });

}