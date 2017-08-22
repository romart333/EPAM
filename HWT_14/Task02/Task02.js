function Parse(expression) {
    var regTextFloat = "\\d+\\.?(\\d)*\\s?";
    var regTextOperator = "[\\+\\-\\*\\/]";
    var regExp = new RegExp('^(' + regTextFloat + ')' + 
        '(' + regTextOperator + regTextFloat + ')*(=)$', 'g');
    if (!regExp.test(expression)) {
        return NaN;
    }

    var numbers = expression.match(new RegExp(regTextFloat, 'g'));
    if (numbers === null) {
        return NaN;
    }
   
    var operators = expression.match(new RegExp(regTextOperator, 'g'));
    if (operators === null) {
        return parseFloat(numbers[0]);
    }

    if ((numbers.length - operators.length) != 1) {
        return NaN;
    }

    function Calculate(numbers, operators) {
        var result = parseFloat(numbers[0]);
        for (var i = 1; i < numbers.length; i++) {
            switch (operators[i - 1]) {
                case "+": {
                    
                    result += parseFloat(numbers[i]);
                    break;
                }
                
                case "-": {
                    result -= parseFloat(numbers[i]);
                    break;
                }

                case "/": {
                    result /= parseFloat(numbers[i]);
                    break;
                }

                case "*": {
                    result *= parseFloat(numbers[i]);
                    break;
                }
            }
        }

        return result.toFixed(2);
    }

    var result = Calculate(numbers, operators);
    return result;
}

var expression = "3.5+4*10-5.3/1.1=";
alert(expression + Parse(expression));//todo pn аналогично 1 заданию