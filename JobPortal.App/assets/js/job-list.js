
    debugger

    $(".slider-handle").focusout(function () {
        alert("out")
    })


function search() {
    debugger;
    var spanState = $("#spanState").text();
    var spanCateg = $("#spanCatg").text();
    spanState = spanState == "Job Location" ? "" : spanState;
    spanCateg = spanCateg == "Job Category" ? "" : spanCateg;    
    var searchStr = $("#SearchString").val();    
    window.location = "/job/Index?searchString=" + searchStr + "&state=" + spanState + "&category=" + spanCateg;
}


function modelSearch(cat) {
    debugger;
    var sliderVal = document.getElementById("price").value.toString().split(',');
  
    var category = cat;
    var minimumSalary = sliderVal[0]
    var maximumSalary = sliderVal[1]

    var dateRange = $('input[name=dateRange]').filter(':checked').val();
    var jobType = $('input[name=jobType]').filter(':checked').val();
    var expLevel = $('input[name=expLevel]').filter(':checked').val();
    var company = $('input[name=companyRadio]').filter(':checked').val();
    var state = $('input[name=stateRadio]').filter(':checked').val();
   

    var searchModel = {
        Category: category,
        MinimumSalary:minimumSalary, 
        MaximumSalary:maximumSalary,
        DateRange: dateRange,
        JobType: jobType,
        ExpLevel: expLevel,
        Company: company,
        State : state
    }

    $("#loadingDiv").show();
    $.ajax({
        type: "POST",
        //dataType: "JSON",
        url: "/Job/Index",
        data: JSON.stringify(searchModel),  //JSON.stringify(vmm),
        contentType: "application/json",
        processData: false,

        success: function (result) {            
            //alert(result)
            //$("html").html($(result).find("html").html());
            //$("#jobsDiv").replaceWith("#jobsDiv", result);
            $("#jobsDiv").html(result);
        },
        error: function () {
            alert("An error occured");
        },
        complete: function () {
            $("#loadingDiv").hide();
        }
    })

}

$("input").change(function () {
    //alert("changed");
    //var formData = new FormData($('form').get(0));
    //formData.append("file", mf);
    modelSearch();
})