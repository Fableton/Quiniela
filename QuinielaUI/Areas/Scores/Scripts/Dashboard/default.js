$(window).on('load', function () {
    LoadLastMatches()
});

function LoadLastMatches() {
    console.log("LoadLastMatches Start");
    $.ajax({
        type: "GET",
        url: "/Scores/Dashboard/ActualMatches"
    }).done(function (response) {
        console.log("LoadLastMatches Done");
        $("#actualMatchesContent").html(response);
    }).fail(function (error) {
        console.log("LoadLastMatches Error");
        console.error(error);
    });
}