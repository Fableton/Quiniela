$(window).on('load', function () {
    LoadLastMatches()
    LoadStats();
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

$(window).on('load', function () {
    LoadLastMatches()
});

function LoadStats() {
    console.log("LoadStats Start");
    $.ajax({
        type: "GET",
        url: "/Scores/Dashboard/BestStats"
    }).done(function (response) {
        console.log("LoadStats Done");
        $("#bestStatsContent").html(response);
    }).fail(function (error) {
        console.log("LoadStats Error");
        console.error(error);
    });
}