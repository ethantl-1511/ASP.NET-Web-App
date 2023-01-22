# C# Web-Application Internship

## Introduction
During this two-week internship with Prosper IT Consulting, I participated in an ASP.NET MVC web-application for a theater company in Oregon. I came into the project mid-development, initially reviewing code and documentation before beginning work. My work involved setting up and styling the Home page, and setting up the Blog-specific area of the website. By the end of the sprint, I had completed three important parts of the website.

The first story I completed was [creating and styling the Home Page](#home-page-styling). I was given a reference to work from, and using Bootstrap 4 and CSS, I made a professionally designed page. After that, I was assigned to the Blog-section of the website, and began with four stories setting up the section where you could view [a list of blog authors.](#blog-authors-stories) After successfully setting that up, I was given another four stories to [create a Head Author admin user](#blog-head-author-stories) to restrict Creating, Updating, and Deleting functionalities.

Below are further descriptions of the extent of my work, along with code snippets animated visual examples. The full code for all of my personal work files are also in this repository.

*Jump to: [Introduction](#introduction), [Home Page Styling](#home-page-styling), [Blog-Authors Stories](#blog-authors-stories), [Blog-Head Author Stories](#blog-head-author-stories), [Other Skills](#other-skills-learned), [Page Top](#c-sharp-internship)*

## Home Page Styling
*Relevant files/folders: 
<a href="https://github.com/ethantl-1511/C-Sharp-Internship/blob/main/Views/Home/Index.cshtml">Index.cshtml</a>, 
<a href="https://github.com/ethantl-1511/C-Sharp-Internship/blob/main/Content/Site.css">Site.css</a>*
<br>

My first task was creating the necessary HTML skeleton and CSS styling to create a Home page according to the Client's design. We utilized a specific naming convention ( [Model]-[Page]-[Element/Name] ) for all styling class and id's to keep sections organized for other team members. 
<br><br>
Below is an animated visual example of the entire Home page I constructed.

<p align="center"><img src="https://github.com/ethantl-1511/C-Sharp-Internship/blob/main/_images/HomePageExample.gif" alt=""></p>
<br>

*Jump to: [Introduction](#introduction), [Home Page Styling](#home-page-styling), [Blog-Authors Stories](#blog-authors-stories), [Blog-Head Author Stories](#blog-head-author-stories), [Other Skills](#other-skills-learned), [Page Top](#c-sharp-internship)*


## Blog-Authors Stories
*Relevant files/folders: 
<a href="https://github.com/ethantl-1511/C-Sharp-Internship/blob/main/Areas/Blog/Models/BlogAuthor.cs">BlogAuthor.cs</a>, 
<a href="https://github.com/ethantl-1511/C-Sharp-Internship/blob/main/Areas/Blog/Controllers/BlogAuthorsController.cs">BlogAuthorsController.cs</a>, 
<a href="https://github.com/ethantl-1511/C-Sharp-Internship/tree/main/Areas/Blog/Views/BlogAuthors">BlogAuthors</a>, 
<a href="https://github.com/ethantl-1511/C-Sharp-Internship/blob/main/Content/Areas/Blog.css">Blog.css</a>, 
<a href="https://github.com/ethantl-1511/C-Sharp-Internship/blob/main/Scripts/Areas/Blog.js">Blog.js</a>*

For this task, I first created the BlogAuthor database model and scaffolded the CRUD pages resulting in the BlogAuthorsController. Then I went to work styling the design of the CRUD pages, each of which would essentially look the same but with minor differences. In order to have the buttons change color and display the appropriate sections, I utilized JavaScript/jQuery to make a switch function that would determine which author's button was being selected from a list of authors.

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
    
Below is an animated visual example of the design, showing off front-end side of the jQuery function. Extra space was left in the card's navbar in case additional buttons would be added at a later time.

<p align="center"><img src="https://github.com/ethantl-1511/C-Sharp-Internship/blob/main/_images/CardExample.gif" alt="CardExample"></p>
<br>

After that, I was tasked with replacing the Index page with a partial view named "\_BlogAuthor.cshmtl" that would reflect the previously created card design. This involved rendering the partial for for each Blog Author in the database. I was then tasked with creating a Delete functionality asyncronously from the card's front-end interface. This involved adding a Json AsyncDelete method to the Controller, setting up the variables in the partial view, and using JavaScript/Ajax to perform the delete and do an animation reflecting the change for the front-end user.

        // Method for Asyncronous Delete function
        [HttpPost]
        [HeadAuthorAuthorize(Roles = "HeadAuthor")]
        public JsonResult AsyncDelete(int id)
        {

            BlogAuthor blogAuthor = db.BlogAuthors.Find(id);
            var result = new JsonResult();

            db.BlogAuthors.Remove(blogAuthor);
            db.SaveChanges();

            return Json(result);
        }

    // Function for blog author partial view delete modal
    function AuthorProfileDeleteModal(cardID, panelID, BlogAuthorId) {
            //Using cardID and panelID to ensure we're on the correct card for deletion
            if (cardID == panelID + 1) {
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
              // Dismiss the modal
              $('.modal').modal('hide');
            }
        }

Below is an animated visual example of JavaScript function in action.

<p align="center"><img src="https://github.com/ethantl-1511/C-Sharp-Internship/blob/main/_images/AsyncDeleteExample.gif" alt="AsyncDeleteExample"></p>
<br>

*Jump to: [Introduction](#introduction), [Home Page Styling](#home-page-styling), [Blog-Authors Stories](#blog-authors-stories), [Blog-Head Author Stories](#blog-head-author-stories), [Other Skills](#other-skills-learned), [Page Top](#c-sharp-internship)*


## Blog-Head Author Stories
*Relevant files/folders:
<a href="https://github.com/ethantl-1511/C-Sharp-Internship/blob/main/Areas/Blog/Models/HeadAuthor.cs">HeadAuthor.cs</a>,
<a href="https://github.com/ethantl-1511/C-Sharp-Internship/blob/main/Areas/Blog/Controllers/BlogAuthorsController.cs">BlogAuthorsController.cs</a>,
<a href="https://github.com/ethantl-1511/C-Sharp-Internship/blob/main/Content/Site.css">Site.css</a>,
<a href="https://github.com/ethantl-1511/C-Sharp-Internship/blob/main/Controllers/AccountController.cs">AccountController.cs</a>,
<a href="https://github.com/ethantl-1511/C-Sharp-Internship/blob/main/Scripts/Areas/Blog.js">Blog.js</a>,
<a href="https://github.com/ethantl-1511/C-Sharp-Internship/tree/main/Views/Shared">Views/Shared</a>*

In this task, I first created the HeadAuthor model to be used as an admin for the Blog Author area and manage other authors. This model would be extended from the ApplicationUser. Afterwards, I needed to create a seed method to create the Head Author user in the database, which involved creating the user role and assigning it. 

    // Seed Database with HeadAuthor for testing purposes
        public static void Seed(ApplicationDbContext context)
        {
            // Entity Framework's RoleManager is used to manage roles, RoleStore will store it. Set to variable roleManager.
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            // Enetity Framework's UserManage does the same as RoleManager, but for Users. Set to variable roleUserManager
            var roleUserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // If the role does not exist...
            if (!roleManager.RoleExists("HeadAuthor"))
            {
                // Create HeadAuthor role
                var modRole = new IdentityRole();
                modRole.Name = "HeadAuthor";
                roleManager.Create(modRole);

                // Create an instance of HeadAuthor and basic properties
                var headAuthor = new HeadAuthor
                {
                    UserName = "HeadAuthor",
                    Email = "HeadAuthor@gmail.com",
                    ViewsPerMonth = 0,
                    AuthorsHired = 0,
                    AuthorsLetGo = 0
                };
                // String variable for password
                string password = "password";

                // Use roleUserManager and passing the new instance and password, create User with variable headAuth
                var headAuth = roleUserManager.Create(headAuthor, password);

                // Check if user-creation is successful,
                if (headAuth.Succeeded)
                {
                    // If it is successful, add new User to role.
                    roleUserManager.AddToRole(headAuthor.Id, "HeadAuthor");
                }
            }
        }

Next, I had to impliment functionality that would restrict any user that was not the HeadAuthor from accessing the Create/Edit/Delete pages. This involved creating a new AccessDenied page to redirect other users to, creating a new class that extends from the Authorize annotation class, and tweaking the Ajax function to redirect. 

    // Method for Head Author
          [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
          public class HeadAuthorAuthorize : AuthorizeAttribute
          {
              public string RedirectURL = "~/Blog/BlogAuthors/AccessDenied";

              protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
              {
                  base.HandleUnauthorizedRequest(filterContext);

                  if (!filterContext.RequestContext.HttpContext.User.Identity.IsAuthenticated)
                  {
                      filterContext.Result = new RedirectResult(RedirectURL);
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

Finally, and ONLY for development and testing purposes, I was tasked with creating a button to login the HeadAuthor user automatically. In order to ensure this button only appeared when a user was not logged in, and only in the Blog Author pages, I came up with a simple if statement in the _Layout.cshtml.

    @if (!Request.IsAuthenticated && Request.Url.AbsoluteUri.Contains("BlogAuthors"))
    {
        @Html.Partial("_LoginBtn-HeadAuthor")
    }
        
Below is an animated visual example of what happens when a user other than Head Author attempts to use the CRUD functionalities.

<p align="center"><img src="https://github.com/ethantl-1511/C-Sharp-Internship/blob/main/_images/AccessDeniedExample.gif" alt="AccessDeniedExample"></p>
<br>

*Jump to: [Introduction](#introduction), [Home Page Styling](#home-page-styling), [Blog-Authors Stories](#blog-authors-stories), [Blog-Head Author Stories](#blog-head-author-stories), [Other Skills](#other-skills-learned), [Page Top](#c-sharp-internship)*


## Other Skills Learned
- Gained experience working with senior developers and management to identify bugs, recieve direction, and solve issues.
- Attained greater understanding of ASP.NET MVC, .NET Framework, and web-application development.
- Solving several diffcult tasks with no prior experience or knowledge gave me greater confidence in personal ability.

*Jump to: [Introduction](#introduction), [Home Page Styling](#home-page-styling), [Blog-Authors Stories](#blog-authors-stories), [Blog-Head Author Stories](#blog-head-author-stories), [Other Skills](#other-skills-learned), [Page Top](#c-sharp-internship)*
