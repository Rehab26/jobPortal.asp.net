
    debugger
    $(function () {

        $("#addRow").click(function (e) {
            e.preventDefault();
            var template = $("#items").find(".itemRow").first();
            var newRow = template.clone();
            newRow.find("input.formfield").val("");
            $("#items").append(newRow);

        });

        $("#addEduRow").click(function (e) {
            e.preventDefault();
            var template = $("#eduItems").find(".eduItemRow").first();
            var newRow = template.clone();
            newRow.find("input.formfield").val("");
            $("#eduItems").append(newRow);
        })

        $("#addExpRow").click(function (e) {
            e.preventDefault();
            var template = $("#expItems").find(".expItemRow").first();
            var newRow = template.clone();
            newRow.find("input.formfield").val("");
            $("#expItems").append(newRow);
        })

        $("#addLangRow").click(function (e) {
            e.preventDefault();
            var template = $("#langItems").find(".langItemRow").first();
            var newRow = template.clone();
            newRow.find("input.formfield").val("");
            $("#langItems").append(newRow);
        })

        //for the below, only the first button triggers the function
        //$("input.btnDeleteEdu").click(function (e) {           
        //    var div = $(e.target).parents("div.eduItemRow.row");
        //    div.remove();
        //})


        $("#btnSubmit").click(function (e) {
            e.preventDefault();
            var _this = $(this);
            var url = _this.closest("form").attr("action");       

            var eduRows = []
            var eduItems = $(".eduItemRow");
            $.each(eduItems, function (i, item) {
                var institutionNamme = $(item).find("input[name='InstitutionNamme']").val();
                var degreeAwarded = $(item).find("input[name='DegreeAwarded']").val();
                var description = $(item).find("textarea[name='Description']").val();
                var startDate = $(item).find("input[name='StartDate']").val();
                var endDate = $(item).find("input[name='EndDate']").val();
                if (institutionNamme && degreeAwarded && startDate && endDate) {
                    var row = { InstitutionNamme: institutionNamme, DegreeAwarded: degreeAwarded, Description: description, StartDate: startDate, EndDate: endDate };
                    eduRows.push(row);
                }
               
            });


            var expRows = []
            var expItems = $(".expItemRow");
            $.each(expItems, function (i, item) {
                var companyName = $(item).find("input[name='CompanyName']").val();
                var designation = $(item).find("input[name='Designation']").val();
                var startDate = $(item).find("input[name='StartDate']").val();
                var endDate = $(item).find("input[name='EndDate']").val();
                var jobDescription = $(item).find("textarea[name='JobDescription']").val();

                if (companyName && designation && startDate && endDate) {
                    var row = { CompanyName: companyName, Designation: designation, StartDate: startDate, EndDate: endDate, JobDescription: jobDescription };
                    expRows.push(row);
                }
                
            });

            var langRows = []
            var langItems = $(".langItemRow");
            $.each(langItems, function (i, item) {
                var name = $(item).find("input[name='name']").val();
                var rating = $(item).find("select[name='langRate']").val();
                //var state = $('input[name=stateRadio]').filter(':checked').val(); 
                //var name = $(item).find("input[name='langRate']").val();

                if (name && rating) {
                    var row = { Name: name, Rating: rating};
                    langRows.push(row);
                }

            });


            var resume = {
                FullName: $("#FullName").val(),
                AdditionalInformation: $("#AdditionalInformation").val(),
                CareerObjective: $("#CareerObjective").val(),
                SkillsAndQualifications: $("#SkillsAndQualifications").val(),
                FatherName: $("#FatherName").val(),
                MotherName: $("#MotherName").val(),
                DateOfBirth: $("#DateOfBirth").val(),
                PlaceOfBirth: $("#PlaceOfBirth").val(),
                Nationality: $("#Nationality").val(),
                Address: $("#Address").val(),
                Declaration: $("#Declaration").val(),
                Gender: $("#Gender").val()
            }
            resume["EducationBackgrounds"] = eduRows
            resume["WorkExperiences"] = expRows
            resume["Languages"] = langRows

            debugger
            var mf = document.getElementById("file").files[0]
          
            var formData = new FormData($('form').get(0));
            formData.append("file", mf);       
            

            //Let's post to server
            $.ajax({
                type: "POST",
                //dataType: "JSON",
                url: "/Profile/SaveImageToFolder",
                data: formData,  //JSON.stringify(vmm),
                contentType: false, // "application/json"
                processData: false,

                error: function(){
                    alert("An error occured while saving your image");
                },

                success: function (result) {
                    //use a default img location in case of a failure
                    resume["ProfileImageUri"] = result.msg
                    //alert(result.msg+" noni")
                    $.ajax({
                        type: "POST",
                        //dataType: "JSON",
                        url: "/Profile/EditResume",
                        data: JSON.stringify(resume),  //JSON.stringify(vmm),
                        contentType: "application/json",
                        processData: false,

                        success: function (result) {
                            alert(result.msg)
                        },
                        error: function () {
                            alert("An error occured");
                        },

                    })
                }

            })
            .done(function (result) {
                //do something with the result
                //alert(result.status)
            })

        });
    });


    function delEdu(el) {
        var btn = $(el);
        var div = btn.parents("div.eduItemRow.row");
        div.remove();
    }
    function delExp(el) {
        var btn = $(el);
        var div = btn.parents("div.expItemRow.row");
        div.remove();
    }
    function delLang(el) {
        var btn = $(el);
        var div = btn.parents("div.langItemRow.row");
        div.remove();
    }
    function LanguageRate(n, el){
        var inp = $(el);
        //var theInp = inp.parents("div.rating-star").find("input[class='myRating']");
        var theInp = inp.parent("div");
        var k = theInp.find("input[class='myRating']");
        //inp.parent()
        theInp.val(n);
    }