
function FuelCalculator(mass){
    var fuel = Math.floor(mass / 3) - 2;
    return (fuel > 0) ? fuel: 0;
}

function FuelFuelCalculator(mass){
    var totalFuel = 0,
        fuel = mass;

    do {
        fuel = FuelCalculator(fuel);
        totalFuel += fuel;
    } while (fuel > 0);
    return totalFuel;
}