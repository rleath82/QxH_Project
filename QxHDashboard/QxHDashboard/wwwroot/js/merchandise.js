window.onload = functSubmit;

function functSubmit() {
    console.log('test');    
    setInterval(reloadTable, 5000);
}

function reloadTable() {
$.ajax({
    type: 'get',
    url: "/Home/RefreshTable",
    success: function (data) {
        var parseData = data;
        for (var i = 0; i < parseData.length; i++) {
            console.log(parseData.length);
            console.log("p" + JSON.stringify(parseData[i]));
            var ele = JSON.stringify(parseData[i]);
            var parsedele = JSON.parse(ele);
            var htmlAttribute = $('[data-item-type="' + parsedele.id + '"]');
            htmlAttribute.children('.1').text(parsedele.planSeqId);
            htmlAttribute.children('.2').text(parsedele.itemId);
            htmlAttribute.children('.3').text(parsedele.itemDescription);
            htmlAttribute.children('.4').text(parsedele.orderQuantity);
            htmlAttribute.children('.5').text(parsedele.orderSldTdy);
            htmlAttribute.children('.6').text(parsedele.avaiForSaleQty);
            htmlAttribute.children('.7').text(parsedele.plannedMinutesQty);
            htmlAttribute.children('.8').text(parsedele.actualMinutesQty);     

            //htmlAttribute.css("background-color", "red");
        }
    }
})
}

