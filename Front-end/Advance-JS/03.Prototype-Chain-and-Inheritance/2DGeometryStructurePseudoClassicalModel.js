if (!Object.prototype.extends) {
    Object.prototype.extends = function (parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    }
}

var Shape = (function () {
    function Shape(x, y, color) {
        if (isNaN(x) || isNaN(y)) {
            throw new Error('Enter valid x and y');
        }

        if (color.substring(0, 1) !== '#') {
            throw new Error('Enter color in hexadecimal format.')
        }

        this._x = x;
        this._y = y;
        this._color = color;
    }

    Shape.prototype.toString = function () {
        return 'color: ' + this._color + ', point A(x: ' + this._x + ' y: ' + this._y + ')';
    };

    return Shape;
})();

var Circle = (function () {
    function Circle(x, y, radius, color) {
        Shape.call(this, x, y, color);

        if (isNaN(radius)) {
            throw new Error('Enter valid radius');
        }

        this._radius = radius;
    }

    Circle.extends(Shape);

    Circle.prototype.toString = function () {
        return 'Circle: ' + Shape.prototype.toString.call(this).replace('A', 'O') + ', radius: ' + this._radius;
    };

    return Circle;
})();

var Rectangle = (function () {
    function Rectangle(x, y, width, heght, color) {
        Shape.call(this, x, y, color);

        if (isNaN(width) || isNaN(heght)) {
            throw new Error('Enter valid width and height');
        }

        this._width = width;
        this._heigth = heght;
    }

    Rectangle.extends(Shape);

    Rectangle.prototype.toString = function () {
        return 'Rectangle: ' + Shape.prototype.toString.call(this) + ', width: ' + this._width + ', height: ' + this._heigth;
    };

    return Rectangle;
})();

var Triangle = (function () {
    function Triangle(xA, yA, xB, yB, xC, yC, color) {
        Shape.call(this, xA, yA, color);

        if (isNaN(xB) || isNaN(yB) || isNaN(xC) || isNaN(xC)) {
            throw new Error('Enter valid B and C points');
        }

        this._xB = xB;
        this._yB = yB;
        this._xC = xC;
        this._yC = yC;
    }

    Triangle.extends(Shape);

    Triangle.prototype.toString = function () {
        return 'Triangle: ' + Shape.prototype.toString.call(this) + ', ' +
            'point B(x: ' + this._xB + ', y: ' + this._yB + '), ' +
            'point C(x: ' + this._xC + ', y: ' + this._yC + ')';
    };

    return Triangle;
})();

var Line = (function () {
    function Line(xA, yA, xB, yB, color) {
        Shape.call(this, xA, yA, color);

        if (isNaN(xB) || isNaN(yB)) {
            throw new Error('Enter valid B points');
        }

        this._xB = xB;
        this._yB = yB;
    }

    Line.extends(Shape);

    Line.prototype.toString = function () {
        return 'Line: ' + Shape.prototype.toString.call(this) + ', ' +
            'point B(x: ' + this._xB + ', y: ' + this._yB + ')';
    };

    return Line;
})();

var Segment = (function () {
    function Segment(xA, yA, xB, yB, color) {
        Shape.call(this, xA, yA, color);

        if (isNaN(xB) || isNaN(yB)) {
            throw new Error('Enter valid B points');
        }

        this._xB = xB;
        this._yB = yB;
    }

    Segment.extends(Shape);

    Segment.prototype.toString = function () {
        return 'Segment: ' + Shape.prototype.toString.call(this) + ', ' +
            'point B(x: ' + this._xB + ', y: ' + this._yB + ')';
    };

    return Segment;
})();

var circle = new Circle(1, 2, 5, '#0000FF');
var rectangle = new Rectangle(2, 3, 4, 6, '#FF0000');
var triangle = new Triangle(1, 3, 3, 4, 6, 7, '#0000FF');
var line = new Line(2.2, 3, 5, 6, '#0000FF');
var segment = new Segment(22, 3, 5, 6, '#FF0000');

console.log(circle.toString());
console.log(rectangle.toString());
console.log(triangle.toString());
console.log(line.toString());
console.log(segment.toString());


