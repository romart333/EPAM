function DeleteRepeatChar(inputString) {
    var punctuations = " \\s?!:;,."
    var i = 0;

    while (i < inputString.length) {
        function MoveByChar(inputString) {
            while (true) {
                if (i === inputString) {
                    return false;
                }

                if (punctuations.indexOf(inputString[i]) === -1) {
                    return true;
                }

                i++;
            }
        }

        if (!MoveByChar(inputString)) {
            return inputString;
        }

        
        function GetWord(inputString) {
            var start = i;
            var word;
            for (; ;) {
                i++;
                if ((i === inputString.length) || (punctuations.indexOf(inputString[i]) != -1)) {
                    break;
                }
            }

            return inputString.substring(start, i);
        }

        var word = GetWord(inputString);

        function DeleteChar(inputString) {
            var j = 0;
            while (j < word.length) {
                var ch = word[j];
                if (word.lastIndexOf(ch) != j) { // несколько одинаковых символов в слове
                    var deletingCharPos;
                    while ((deletingCharPos = word.indexOf(ch)) != -1) {
                        if (deletingCharPos <= j) {
                            j--;
                        }

                        word = word.replace(ch, "");
                    }

                    while ((deletingCharPos = inputString.indexOf(ch)) != -1) {
                        if (deletingCharPos < i) {
                            i--;
                        }

                        inputString = inputString.replace(ch, "");
                    }                    
                }

                j++;
            }

            return inputString;
        }

        inputString = DeleteChar(inputString);
        i++;
    }

    return inputString;
}


var inputString = "У попа была собака";
alert(inputString);
alert(DeleteRepeatChar(inputString));