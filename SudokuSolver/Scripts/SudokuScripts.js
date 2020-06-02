document.addEventListener('DOMContentLoaded', function () {
    var datacellCollection = document.getElementsByClassName("cell");
    Array.prototype.forEach.call(datacellCollection, RemoveZeros);

    function RemoveZeros(currentDataCell) {
        if (currentDataCell.value == "0") {
            currentDataCell.value = "";
            currentDataCell.disabled = true;
        } else {
            currentDataCell.disabled = true;
        }
    }
});

var userLevel = 1;

function ToggleUserControl(level) {
    userLevel = level;
    var datacellCollection = document.getElementsByClassName("cell");
    Array.prototype.forEach.call(datacellCollection, Toggle);
}

function Toggle(dataCell) {
    var tag = dataCell.getAttribute("tag");

    if (userLevel == "0") {
        dataCell.disabled = true;
    }
    else if (userLevel == "1") {
        if (tag != "0") {
            dataCell.value = parseInt(dataCell.getAttribute("tag"));
            dataCell.disabled = true;
        }
        if (tag == "0") {
            dataCell.disabled = false;
        }
    }
    else {
        dataCell.disabled = false;
    }

}

function ValidateInput(dataCell) {
    //Remove User made 0.
    if (dataCell.value == "0") {
        dataCell.value = "";
    }

    var tag = dataCell.getAttribute("tag");

    //ClientSide Sudoku validation?
    if (tag == "0") {
        var coordinate = dataCell.name;
        //console.log(name);
        var row = coordinate.slice(coordinate.indexOf("[") + 1, coordinate.indexOf("]"));
        //console.log(row);
        var column = coordinate.slice(coordinate.indexOf("]") + 2, coordinate.indexOf("]") + 3);
        //console.log(column);
        var datacellRow = new Array();
        var datacellColumn = new Array();
        var datacellBLock = new Array();
        for (var i = 0; i < 9; i++) {
            if (i != column) {
                datacellRow.unshift(document.getElementsByName("Cells[" + row + "][" + i + "]"));
            }
            if (i != row) {
                datacellColumn.unshift(document.getElementsByName("Cells[" + i + "][" + column + "]"));
            }
        }
        //TODO: Add block array and validation code.
        var startCol = Math.floor(parseInt(column) / 3);
        var startRow = Math.floor(parseInt(row) / 3);
        for (var i = startRow; i < startRow+3; i++) {
            for (var j = startCol; j < startCol+3; j++) {
                if (!(i == row && j == column)) {
                    datacellBLock.unshift(document.getElementsByName("Cells[" + i + "][" + j + "]"));
                }
            }
        }
        console.log(datacellBLock);
    }
}

function SelectionChanged(sudokuId) {
    location.href = 'Sudoku/ChangeSudoku/' + sudokuId;
}