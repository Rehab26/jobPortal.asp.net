function search() {
    debugger;
    var spanState = $("#spanState").text();
    var spanCateg = $("#spanCatg").text();
    spanState = spanState == "Job Location" ? "" : spanState;
    spanCateg = spanCateg == "Job Category" ? "" : spanCateg;
    var searchStr = $("#SearchString").val();
    window.location = "../job/S?s=" + searchStr + "&st=" + spanState + "&ct=" + spanCateg;
}


function modelSearch(cat) {
    debugger;

    var category = cat;

    var t = $("#JobSearchViewModel_Category")
    t.val(cat);
    $("#form").submit();

}