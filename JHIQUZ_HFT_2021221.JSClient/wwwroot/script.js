﻿let cars = [];
const connection;
getdata();




async function getdata() {
    await fetch('http://localhost:51322/car')
        .then(x => x.json())
        .then(y => {
            cars = y
            console.log(cars);
            display();
        });
}

function display() {
    document.getElementById('resultArea').innerHTML = "";
    cars.forEach(t => {
        document.getElementById('resultArea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.brand.name + "</td><td>" + t.model + "</td><td>" + t.basePrice + "</td><td>" + t.engine.ccm + "</td><td>" + `<button type="button" class="btn btn-danger" onclick="remove(${t.id})">Delete</button>` + "</td></tr>";
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