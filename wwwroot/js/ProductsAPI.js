
//run the LoadTable function when the page has loaded
$(document).ready(function () {
    LoadTable();
});



const uri = "/api/ProductsAPI"; //the api as a global variable
//  alert("API " + uri);
let allProducts = null; //holds the data in a global

//Loads up the  <p id="counter"> </p> with a count of the products, data come from the LoadTable Function where this is called
function getCount(data) {
    //  alert("getcount " + datas);
    const theCount = $("#counter"); //bind TheCount to the counter
    if (data) { //if any data exists
        // alert("We have data " + data);
        theCount.text("There are " + data + " Products");
    } else {
        theCount.text("There are no Products");
        alert("No data");
    }
}

//this function reloads the table of products after any changes
function LoadTable() {
    //  alert("Some data");
    $.ajax({
        type: "GET", //use the GET controller
        url: uri, //the uri from the global
        cache: false, //don't cache the data in browser reloads, get a fresh copy
        success: function (data) { //if the request succeeds ....
            const tBody = $("#allProducts"); //for the tbody bind with allProducts  <tbody id="allStaff"></tbody>
            allProducts = data; //pass in all the data to the global allProducts use it in Edit
            $(tBody).empty(); //empty out old data
            //  alert("boop");
            getCount(data.length); //count for the counter function

            //a foreach through the rows creating table data
            $.each(data,
                function (key, item) {
                    //    alert(item.Name);
                    const tr = $("<tr></tr>")
                        .append($("<td></td>").text(item.name)) //inserts content in the tags
                        .append($("<td></td>").text(item.price))
                        .append($("<td></td>").text(item.quantity))
                        .append($("<td></td>").text(item.shippingPrice))
                        .append($("<td></td>")
                            .append($("<button>Edit</button>")
                                .on("click",
                                    function () {
                                        editItem(item.id);
                                    }) //in the empty cell append in an edititem button
                            )
                        )
                        .append(
                            $("<td></td>").append(
                                $("<button>Delete</button>").on("click",
                                    function () {
                                        deleteItem(item.id);
                                    })//in an empty cell add in a deleteitem button
                            )
                        );
                    tr.appendTo(tBody);//add all the rows to the tbody
                });
        }
    });
}
//Add a product to the database
function addItem() {
    const item = {
        name: $("#add-Name").val(),
        Price: $("#add-Price").val(),
        Quantity: $("#add-Quantity").val(),
        ShippingPrice: $("#add-ShippingPrice").val()
    };

    $.ajax({
        type: "POST", //this calls the POST in the API controller
        accepts: "application/json",
        url: uri,
        contentType: "application/json",
        data: JSON.stringify(item),
        //if there is an error
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
        },
        //if it is successful
        success: function (result) {
            LoadTable();
            $("#add-Name").val(""); //clear entry boxes
            $("#add-Price").val("");
            $("#add-Quantity").val("");
            $("#add-ShippingPrice").val("");
            alert("Product added successfully");
        }
    });
}
//Delete a person from the database
function deleteItem(id) {
    $.ajax({
        url: uri + "/" + id, //add the ID to the end of the URI
        type: "DELETE", //this calls the DELETE in the API controller
        success: function (result) {
            LoadTable();
        }
    });
}
//click event for edit button to load details into form. Go through each entry held in allStaff and add in the one that matches the id from the click
function editItem(id) {
    $.each(allProducts,
        function (key, item) {
            if (item.id === id) {//where the ID == the one on the click
                $("#edit-Name").val(item.name); //add it to the form field
                $("#edit-Id").val(item.id);
                $("#edit-Price").val(item.price);
                $("#edit-Quantity").val(item.quantity);
                $("#edit-ShippingPrice").val(item.shippingPrice);
            }
        });
}

$(".my-form").on("submit", //saving the edit to the db
    function () {
        const item = { //pass all the data on the form to a variable called item use later to send to server
            Name: $("#edit-Name").val(),
            Price: $("#edit-Price").val(),
            Quantity: $("#edit-Quantity").val(),
            ShippingPrice: $("#edit-ShippingPrice").val(),
            Id: $("#edit-Id").val()
        };

        alert("Saving ... " + item.Id + " " + item.Name + " " + item.Price + " " + item.Quantity + " " + item.ShippingPrice);

        $.ajax({
            url: uri + "/" + $("#edit-Id").val(), //add the row id to the uri
            type: "PUT", //send it to the PUT controller
            accepts: "application/json",
            contentType: "application/json",
            data: JSON.stringify(item), //take the item data and pass it to the serever data is moved to server
            success: function (result) {
                LoadTable(); //load the table afresh
            }
        });
        return false;
    });