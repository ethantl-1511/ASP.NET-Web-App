// Blog Author section
// Function for switching between individual card panels
function AuthorProfileMenuSwitch(buttonID, panelID)
{
    switch (buttonID % 3) // if another button is added, increment by 1
    {   // checks each what buttonID is clicked and changes button-specific classes and panel-specific details accordingly
        case 1:
            {
                $("#blogauthors-detailsdelete--navbtn--" + buttonID).removeClass('btn-dark').addClass("btn-success");
                $("#blogauthors-detailsdelete--navbtn--" + (buttonID + 1)).removeClass('btn-success').addClass("btn-dark");
                $("#blogauthors-detailsdelete--navbtn--" + (buttonID + 2)).removeClass('btn-success').addClass("btn-dark");

                $("#blogauthors-detailsdelete--authordetails--" + panelID).show().css("visibility", "visible");
                $("#blogauthors-detailsdelete--blogposts--" + panelID).hide().css("visibility", "hidden");
                $("#blogauthors-detailsdelete--contact--" + panelID).hide().css("visibility", "hidden");
                break;
            }
        case 2:
            {
                $("#blogauthors-detailsdelete--navbtn--" + buttonID).removeClass('btn-dark').addClass("btn-success");
                $("#blogauthors-detailsdelete--navbtn--" + (buttonID - 1)).removeClass('btn-success').addClass("btn-dark");
                $("#blogauthors-detailsdelete--navbtn--" + (buttonID + 1)).removeClass('btn-success').addClass("btn-dark");

                $("#blogauthors-detailsdelete--authordetails--" + panelID).hide().css("visibility", "hidden");
                $("#blogauthors-detailsdelete--blogposts--" + panelID).show().css("visibility", "visible");
                $("#blogauthors-detailsdelete--contact--" + panelID).hide().css("visibility", "hidden");
                break;
            }
        case 0:  // if another button is added, rename this case # incremented by 1 and create new [case 0] below for new button
            {
                $("#blogauthors-detailsdelete--navbtn--" + buttonID).removeClass('btn-dark').addClass("btn-success");
                $("#blogauthors-detailsdelete--navbtn--" + (buttonID - 2)).removeClass('btn-success').addClass("btn-dark");
                $("#blogauthors-detailsdelete--navbtn--" + (buttonID - 1)).removeClass('btn-success').addClass("btn-dark");

                $("#blogauthors-detailsdelete--contact--" + panelID).show().css("visibility", "visible");
                $("#blogauthors-detailsdelete--authordetails--" + panelID).hide().css("visibility", "hidden");
                $("#blogauthors-detailsdelete--blogposts--" + panelID).hide().css("visibility", "hidden");
                break;
            }
    }
}

// Function for blog author partial view delete modal
function AuthorProfileDeleteModal(cardID, panelID, BlogAuthorId) {
    //Using cardID and panelID to ensure we're on the correct card for deletion
    if (cardID == panelID + 1) {
        if (userAuthorized) {
            // Delete author from backend-database
            $.ajax({
                type: "POST",
                url: "/BlogAuthors/AsyncDelete",
                data: { id: BlogAuthorId },
                success: function () {
                    // Animation that gradually "deletes" blog author from frontend-view
                    $("#blogauthors-partialview--card--" + cardID).slideUp(1300);
                },
                error: function () {
                    alert("Error occured. Author data could not be deleted.");
                }
            });
        }
        else {
            window.location.replace("/Blog/BlogAuthors/AccessDenied");
        }
        // Dismiss the modal
        $('.modal').modal('hide');
    }
}