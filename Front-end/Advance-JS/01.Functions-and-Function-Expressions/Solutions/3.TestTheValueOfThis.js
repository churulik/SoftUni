function testContext() {
    console.log(this)
}

function insideAnotherFunction() {
    testContext()
}

testContext();

insideAnotherFunction();

new testContext();