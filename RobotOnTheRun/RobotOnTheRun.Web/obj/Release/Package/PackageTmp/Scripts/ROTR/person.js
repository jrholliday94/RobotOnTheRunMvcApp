function SearchPerson(guid) {
    var search = guid;

    $.ajax({
        url: "Search",
        data: { searchGuid: search },
    }).done(function (data) {
        $("#personId").val(data.PersonId);
        $("#firstName").val(data.FirstName);
        $("#lastName").val(data.LastName);
        $("#dateCreated").val(data.DateCreated);
        $("#email").val(data.Email);
        $("#phoneNumber").val(data.PhoneNumber);

        if (data.FirstName == null) {
            document.getElementById("personForm").style.visibility = "hidden";
            document.getElementById("createProfile").style.visibility = "visible";
        } else {
            document.getElementById("createProfile").style.visibility = "hidden";
            document.getElementById("personForm").style.visibility = "visible";
        }

        });

}

function UpdatePerson(guid) {
    var personId = guid;
    var firstName = $("#firstName").val();
    var lastName = $("#lastName").val();
    var gender = $("#gender").val();
    var email = $("#email").val();
    var phoneNumber = $("#phoneNumber").val();

    $.ajax({
        url: "UpdatePerson",
        dataType: "json",
        data: {
            PersonId: personId,
            FirstName: firstName,
            LastName: lastName,
            Gender: gender,
            PhoneNumber: phoneNumber,
            Email: email
        }
    }).done(function (data) {
        if (data) {
            $("#successMessage").removeClass("hidden")
                .addClass("visible");
        }
        else {
            $("#errorMessage").removeClass("hidden")
                .addClass("visible");
        }
        });
}