
//run the LoadTable function when the page has loaded
$(document).ready(function () {
    LoadTable();
});



const uri = "/api/StaffNamesAPI"; //the api as a global variable
//  alert("API " + uri);
let allStaff = null; //holds the data in a global

//Loads up the  <p id="counter"> </p> with a count of the staff, data come from the LoadTable Function where this is called
function getCount(data) {
    //  alert("getcount " + datas);
    const theCount = $("#counter"); //bind TheCount to the counter
    if (data) { //if any data exists
        //   alert("We have data " + data);
        theCount.text("There are " + data + " Staff");
    } else {
        theCount.text("There are no Staff");
        alert("No data");
    }
}

//this function reloads the table of staff after any changes
function LoadTable() {
    $.ajax({
        type: "GET", //use the GET controller
        url: uri, //the uri from the global
        cache: false, //don't cache the data in browser reloads, get a fresh copy
        success: function (data) { //if the request succeeds ....
            const tBody = $("#allStaff"); //for the tbody bind with allstaff  <tbody id="allStaff"></tbody>
            allStaff = data; //pass in all the data to the global allstaff use it in Edit
            $(tBody).empty(); //empty out old data

            getCount(data.length); //count for the counter function

            //a foreach through the rows creating table data
            $.each(data,
                function (key, item) {
                    const tr = $("<tr></tr>")
                        .append($("<td></td>").text(item.name)) //inserts content in the tags
                        .append($("<td></td>").text(item.department))
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
//Add an person to the database
function addItem() {
    const item = {
        name: $("#add-name").val(),
        department: $("#add-department").val()
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
            $("#add-name").val(""); //clear entry boxes
            $("#add-department").val("");
            alert("Staff added successfully");
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
    $.each(allStaff,
        function (key, item) {
            if (item.id === id) {//where the ID == the one on the click
                $("#edit-name").val(item.name); //add it to the form field
                $("#edit-id").val(item.id);
                $("#edit-department").val(item.department);
            }
        });
}

$(".my-form").on("submit", //saving the edit to the db
    function () {
        const item = { //pass all the data on the form to a variable called item use later to send to server
            name: $("#edit-name").val(),
            department: $("#edit-department").val(),
            id: $("#edit-id").val()
        };

        alert("Saving ... " + item.id + " " + item.name + " " + item.department);

        $.ajax({
            url: uri + "/" + $("#edit-id").val(), //add the row id to the uri
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


