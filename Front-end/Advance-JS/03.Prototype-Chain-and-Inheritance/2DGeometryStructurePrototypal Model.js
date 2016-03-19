if (!Object.prototype.extend) {
    Object.prototype.extend = function (properties) {
        function Func() {
        }

        Func.prototype = Object.create(this);
        for (var prop in properties) {
            Func.prototype[prop] = properties[prop];
        }

        Func.prototype._super = this;
        return new Func();
    };
}

var Shape = (function () {
    var shape = {
        init: function (x, y, color) {
            if (isNaN(x) || isNaN(y)) {
                throw new Error('Enter valid x and y');
            }

            if (color.substring(0, 1) !== '#') {
                throw new Error('Enter color in hexadecimal format.')
            }

            this._x = x;
            this._y = y;
            this._color = color;
        },
        toString: function () {
            return 'color: ' + this._color + ', point A(x: ' + this._x + ' y: ' + this._y + ')';
        }
    };

    var circle = shape.extend({
        init: function (x, y, radius, color) {
            this._super.init.call(this, x, y, color);

            if (isNaN(radius)) {
                throw new Error('Enter valid radius');
            }

            this._radius = radius;

            return this;
        },
        toString: function () {
            return 'Circle: ' + this._super.toString.call(this).replace('A', 'O') + ', radius: ' + this._radius;
        }
    });

    var rectangle = shape.extend({
        init: function (x, y, width, height, color) {
            this._super.init.call(this, x, y, color);

            if (isNaN(width) || isNaN(height)) {
                throw new Error('Enter valid width and height');
            }

            this._width = width;
            this._heigth = height;

            return this;
        },
        toString: function () {
            return 'Rectangle: ' + this._super.toString.call(this) + ', width: ' + this._width + ', height: ' + this._heigth;
        }

    });

    var triangle = shape.extend({
        init: function (xA, yA, xB, yB, xC, yC, color) {
            this._super.init.call(this, xA, yA, color);

            if (isNaN(xB) || isNaN(yB) || isNaN(xC) || isNaN(xC)) {
                throw new Error('Enter valid B and C points');
            }

            this._xB = xB;
            this._yB = yB;
            this._xC = xC;
            this._yC = yC;

            return this;
        },
        toString: function () {
            return 'Triangle: ' + this._super.toString.call(this) + ', ' +
                'point B(x: ' + this._xB + ', y: ' + this._yB + '), ' +
                'point C(x: ' + this._xC + ', y: ' + this._yC + ')';
        }
    });

    var line = shape.extend({
        init: function (xA, yA, xB, yB, color) {

            this._super.init.call(this, xA, yA, color);
            if (isNaN(xB) || isNaN(yB)) {
                throw new Error('Enter valid B points');
            }

            this._xB = xB;
            this._yB = yB;

            return this;
        },
        toString: function () {
            return 'Line: ' + this._super.toString.call(this) + ', ' +
                'point B(x: ' + this._xB + ', y: ' + this._yB + ')';
        }
    });

    var segment = shape.extend({
        init: function (xA, yA, xB, yB, color) {
            this._super.init.call(this, xA, yA, color);

            if (isNaN(xB) || isNaN(yB)) {
                throw new Error('Enter valid B points');
            }

            this._xB = xB;
            this._yB = yB;

            return this;
        },
        toString: function () {
            return 'Segment: ' + this._super.toString.call(this) + ', ' +
                'point B(x: ' + this._xB + ', y: ' + this._yB + ')';

        }
    });

    return {
        circle: circle,
        rectangle: rectangle,
        triangle: triangle,
        line: line,
        segment: segment
    }
})();

var circle = Shape.circle.init(1, 2, 4, '#FF0000');
var rectangle = Shape.rectangle.init(2, 4, 4, 4, '#FFFF00');
var triangle = Shape.triangle.init(1, 1, 2, 2, 3, 3, '#00FF00');
var line = Shape.line.init(2.1, 1, 2, 2.5, '#0000FF');
var segment = Shape.segment.init(1.1, 3, 2.7, 5, '#FFFF00');

console.log(circle.toString());
console.log(rectangle.toString());
console.log(triangle.toString());
console.log(line.toString());
console.log(segment.toString());