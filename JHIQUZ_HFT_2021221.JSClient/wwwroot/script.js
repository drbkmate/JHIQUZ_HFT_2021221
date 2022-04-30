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
        console.log(t.Model)
    });
}