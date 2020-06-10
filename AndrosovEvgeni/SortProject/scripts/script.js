function boxSort(how) {
    var divs = document.getElementsByClassName("col-md-4");
    var divs_txt = [];
    for (var i = 0; i < divs.length; i++) {
        divs_txt[i] = parseFloat(divs[i].innerHTML);
    }

    if (how == 1)
        divs_txt.sort(sortAsc) //Массив будет [7, 8, 25, 41]
    else if (how == 2)
        divs_txt.sort(sortDesc);

    for (var i = 0; i < divs_txt.length; i++) {
        divs_txt[i] = '<div class="col-md-4 bordered">' + divs_txt[i] + '<span class = "cross">x</span></div>';

        var txt = divs_txt.join('');

        document.getElementById("goods").innerHTML = txt;

        init();
    }
}

function sortAsc(a, b) {
    return a - b;
}
function sortDesc(a, b) {
    return b - a;
}

function init() {
    $('.cross').click(function () {
        $(this).parent(".col-md-4").fadeOut(2000, function () { $(this).remove() });
    });
}
function addBlock() {
    var block = document.createElement("DIV");
    block.setAttribute("class", "col-md-4 bordered");
    block.innerHTML = Math.floor(Math.random() * (1600));
    document.getElementById("goods").appendChild(block);

    var cross = document.createElement("span");
    cross.setAttribute("class", "cross");
    cross.innerHTML = "x";
    block.appendChild(cross);
    init();
}

function resetAll() {
    document.getElementById("goods").innerHTML = "";
}

window.onload = init;
