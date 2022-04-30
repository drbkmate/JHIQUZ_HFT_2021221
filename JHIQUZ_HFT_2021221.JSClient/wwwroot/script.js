fetch('http://localhost:51322/car')
    .then(x => x.json())
    .then(y => console.log(y));