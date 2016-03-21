function calcSupply(age, maxAge, food, foodPerDay){
    var foodTillEnd = ((maxAge - age) * foodPerDay) * 365;
    console.log(foodTillEnd + "kg of chocolate would be enough until I am " + maxAge + " years old.");
}

calcSupply(38, 118, 'chocolate', 0.5);
calcSupply(20, 87, 'fruits', 2);
calcSupply(16, 102, 'nuts', 1.1);