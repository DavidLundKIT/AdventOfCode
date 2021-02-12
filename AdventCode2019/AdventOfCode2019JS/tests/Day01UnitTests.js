QUnit.module("Day 01 Fuel Counter-Upper tests part 1", function() {

    QUnit.test("Test mass 12", function(assert){
        var mass = 12;
        var expected = 2;
        var actual = FuelCalculator(mass);
        assert.equal(actual, expected, "Gives fuel 2");
    });

    QUnit.test("Test mass 14", function(assert){
        var mass = 14;
        var expected = 2;
        var actual = FuelCalculator(mass);
        assert.equal(actual, expected, "Gives fuel 2");
    });

    QUnit.test("Test mass 1969", function(assert){
        var mass = 1969;
        var expected = 654;
        var actual = FuelCalculator(mass);
        assert.equal(actual, expected, "Gives fuel 654");
    });

    QUnit.test("Test mass 100756", function(assert){
        var mass = 100756;
        var expected = 33583;
        var actual = FuelCalculator(mass);
        assert.equal(actual, expected, "Gives fuel 33583");
    });


    QUnit.test("Solution Part 1", function(assert){
        var masses = DataDay01;
        var mass = 0,
            fuel = 0,
            totalFuel = 0;
        var expected = 3452245;

        for (let idx = 0; idx < masses.length; idx++) {
            fuel =  FuelCalculator(masses[idx]);
            totalFuel += fuel;
        }

        assert.equal(totalFuel, expected, "Gives fuel 3452245");
    });
});

QUnit.module("Day 01 Fuel Counter-Upper tests part 2", function() {

    QUnit.test("Test mass 12", function(assert){
        var mass = 12;
        var expected = 2;
        var actual = FuelFuelCalculator(mass);
        assert.equal(actual, expected, "Gives fuel 2");
    });

    QUnit.test("Test mass 14", function(assert){
        var mass = 14;
        var expected = 2;
        var actual = FuelFuelCalculator(mass);
        assert.equal(actual, expected, "Gives fuel 2");
    });

    QUnit.test("Test mass 1969", function(assert){
        var mass = 1969;
        var expected = 966;
        var actual = FuelFuelCalculator(mass);
        assert.equal(actual, expected, "Gives fuel 966");
    });

    QUnit.test("Test mass 100756", function(assert){
        var mass = 100756;
        var expected = 50346;
        var actual = FuelFuelCalculator(mass);
        assert.equal(actual, expected, "Gives fuel 50346");
    });


    QUnit.test("Solution Part 2", function(assert){
        var masses = DataDay01;
        var mass = 0,
            fuel = 0,
            totalFuel = 0;
        var expected = 5175499;

        for (let idx = 0; idx < masses.length; idx++) {
            fuel =  FuelFuelCalculator(masses[idx]);
            totalFuel += fuel;
        }

        assert.equal(totalFuel, expected, "Gives fuel 5175499");
    });

    QUnit.test("Subway", function(assert){
        var s = " ";
        var a = 3;
        while (a != 1)        {
            s = s + a;
            if (a % 2 == 0) {
                a = a/2;
            } else {
                a = 3 * a + 1;
            }
        }
        assert.equal("xxx", s, "Multisoft stuff");

    });
});
