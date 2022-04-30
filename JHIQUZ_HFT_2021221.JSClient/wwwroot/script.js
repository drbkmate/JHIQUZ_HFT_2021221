let cars = [];
fetch('http://localhost:51322/car')
    .then(x => x.json())
    .then(y => {
        cars = y
        console.log(cars);
        display();
    });



function display() {
    cars.forEach(t => {
        document.getElementById('resultArea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.brand.name + "</td><td>" + t.model + "</td><td>" + t.basePrice + "</td><td>" + t.engine.ccm + "</td></tr>";
        console.log(t.model)
    });
}