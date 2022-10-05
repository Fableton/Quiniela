function AddPLayer() {

    let name = $("#name").val();
    $.ajax({
        type: "POST",
        url: "/Admin/Players/Add",
        data: { name: name }
    }).done(function (response) {
        $(".invalid-feedback").hide()
        if (response.errors && response.errors.length > 0) {

            $.each(response.errors, function (key, value) {
                console.log(value);
                console.log($("#" + value));
                $("#" + value).show();
            });

            $("#name").addClass("is-invalid");
        } else {
            $("#newModal").modal('toggle');
            $("#name").val("");
            $("#newPLayer").html(response.data.name)
            var toast = new bootstrap.Toast($("#sucessToast"))
            toast.show()
            UpdatePlayersTable(response.data.id);
        }
    }).fail(function () {
        alert("error");
    });
}

function UpdatePlayersTable(newPlayerID) {
    $.ajax({
        type: "GET",
        url: "/Admin/Players/PlayersTable",
        data: { newPLayerId: newPlayerID }
    }).done(function (response) {
        console.log(response);
        $("#PlayerTableContainer").html(response);
    })
        .fail(function (error) {
            console.error(error);
        });
}

function GenerateLink(playerId) {
    $(".generalLinkButton").find(".original").show();
    $(".generalLinkButton").find(".result").hide();
    $.ajax({
        type: "GET",
        url: "/Admin/Players/GenerateLink",
        data: { playerId: playerId }
    }).done(function (response) {
        $("#GeneralLinkButton_" + playerId).find(".original").hide();
        $("#GeneralLinkButton_" + playerId).find(".result").show();
        console.log(response.data)
        copyToClipboard(response.data);
    }).fail(function (error) {
        console.error(error);
    });
}