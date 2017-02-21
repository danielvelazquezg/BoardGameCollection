describe("BoardGameCollection", function () {
    var calc;

    beforeEach(function () {
        calc = new Calculator();
    });

    it('Should be able to add 1 and 1', function () {    
        expect(calc.add(1,1)).toBe(2);
    });

    it('Should be able to divide 6 and 2', function () {
        expect(calc.divide(6, 2)).toBe(3);
    });
});