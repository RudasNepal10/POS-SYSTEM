function customParseFloat(num, decimalPoints = 2) {
    return parseFloat(parseFloat(num).toFixed(decimalPoints));
}

$.fn.valueAsNumber = function () {
    return +(this.val());
};
