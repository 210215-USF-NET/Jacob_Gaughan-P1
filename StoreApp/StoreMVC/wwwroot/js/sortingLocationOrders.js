document.getElementById('sortSelector').onchange = changeSorting;

function changeSorting() {
    var table, rows, switching, i, x, y, shouldSwitch;
    table = document.getElementById("orderTable");
    switch (this.value) {
        case "SortByDateOldToNew":
            switching = true;
            while (switching) {
                switching = false;
                rows = table.rows;
                for (i = 1; i < (rows.length - 1); i++) {
                    shouldSwitch = false;
                    x = rows[i].getElementsByTagName("td")[1];
                    y = rows[i + 1].getElementsByTagName("td")[1];
                    if (x.innerHTML > y.innerHTML) {
                        shouldSwitch = true;
                        break;
                    }
                }
                if (shouldSwitch) {
                    rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
                    switching = true;
                }
            }
            console.log("Sorted By Date Old To New");
            break;
        case "SortByDateNewToOld":
            switching = true;
            while (switching) {
                switching = false;
                rows = table.rows;
                for (i = 1; i < (rows.length - 1); i++) {
                    shouldSwitch = false;
                    x = rows[i].getElementsByTagName("td")[1];
                    y = rows[i + 1].getElementsByTagName("td")[1];
                    if (x.innerHTML < y.innerHTML) {
                        shouldSwitch = true;
                        break;
                    }
                }
                if (shouldSwitch) {
                    rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
                    switching = true;
                }
            }
            console.log("Sorted By Date New To Old");
            break;
        case "SortByPriceHighToLow":
            switching = true;
            while (switching) {
                switching = false;
                rows = table.rows;
                for (i = 1; i < (rows.length - 1); i++) {
                    shouldSwitch = false;
                    x = rows[i].getElementsByTagName("td")[2].innerHTML;
                    y = rows[i + 1].getElementsByTagName("td")[2].innerHTML;

                    if (parseFloat(x) < parseFloat(y)) {
                        shouldSwitch = true;
                        break;
                    }
                }
                if (shouldSwitch) {
                    rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
                    switching = true;
                }
            }
            console.log("Sorted By Price High To Low");
            break;
        case "SortByPriceLowToHigh":
            switching = true;
            while (switching) {
                switching = false;
                rows = table.rows;
                for (i = 1; i < (rows.length - 1); i++) {
                    shouldSwitch = false;
                    x = rows[i].getElementsByTagName("td")[2].innerHTML;
                    y = rows[i + 1].getElementsByTagName("td")[2].innerHTML;
                    if (parseFloat(x) > parseFloat(y)) {
                        shouldSwitch = true;
                        break;
                    }
                }
                if (shouldSwitch) {
                    rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
                    switching = true;
                }
            }
            console.log("Sorted By Price Low To High");
            break;
        case "SortByCustomer":
            switching = true;
            while (switching) {
                switching = false;
                rows = table.rows;
                for (i = 1; i < (rows.length - 1); i++) {
                    shouldSwitch = false;
                    x = rows[i].getElementsByTagName("td")[0];
                    y = rows[i + 1].getElementsByTagName("td")[0];
                    if (x.innerHTML > y.innerHTML) {
                        shouldSwitch = true;
                        break;
                    }
                }
                if (shouldSwitch) {
                    rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
                    switching = true;
                }
            }
            console.log("Sorted By Customer");
            break;
        default:
            console.log("default selector");
    }
}