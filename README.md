# C-Sharp-Internship

## Introduction
During this two-week internship with Prosper IT Consulting, I participated in an ASP.NET MVC web-application for a theater company in Oregon. I came into the project mid-development, initially reviewing code and documentation before beginning work. My work involved setting up and styling the Home page, and setting up the Blog-specific area of the website. By the end of the sprint, I had completed three important parts of the website.

The first story I completed was [creating and styling the Home Page](#home-page-styling). I was given a reference to work from, and using Bootstrap 4 and CSS, I made a professionally designed page. After that, I was assigned to the Blog-section of the website, and began with four stories setting up the section where you could view [a list of blog authors](#blog-authors-stories). After successfully setting that up, I was given another four stories to [create a Head Author admin user](#blog-head-author-stories) to restrict Creating, Updating, and Deleting functionalities.

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
<br><br>
Below is an animated visual example of the design, showing off front-end side of the jQuery function. Extra space was left in the card's navbar in case additional buttons would be added at a later time.

<p align="center"><img src="https://github.com/ethantl-1511/C-Sharp-Internship/blob/main/_images/CardExample.gif" alt="CardExample"></p>
<br>

After that, I was tasked with replacing the Index page with a partial view named "\_BlogAuthor.cshmtl" that would reflect the previously created card design. This involved rendering the partial for for each Blog Author in the database. I was then tasked with creating a Delete functionality asyncronously from the card's front-end interface. This involved adding a Json AsyncDelete method to the Controller, setting up the variables in the partial view, and using JavaScript/Ajax to perform the delete and do an animation reflecting the change for the front-end user.
<br><br>
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

In this task, I first created the HeadAuthor model to be used as an admin for the Blog Author area and manage other authors. This model would be extended from the ApplicationUser. Afterwards, I needed to create a seed method to create the Head Author user in the database, which involved creating the user role and assigning it. Next, I had to impliment functionality that would restrict any user that was not the HeadAuthor from accessing the Create/Edit/Delete pages. This involved creating a new AccessDenied page to redirect other users to, creating a new class that extends from the Authorize annotation class, and tweaking the Ajax function to redirect.
<br><br>
Below is an animated visual example of what happens when a user other than Head Author attempts to use the CRUD functionalities.

<p align="center"><img src="https://github.com/ethantl-1511/C-Sharp-Internship/blob/main/_images/AccessDeniedExample.gif" alt="AccessDeniedExample"></p>
<br>

*Jump to: [Introduction](#introduction), [Home Page Styling](#home-page-styling), [Blog-Authors Stories](#blog-authors-stories), [Blog-Head Author Stories](#blog-head-author-stories), [Other Skills](#other-skills-learned), [Page Top](#c-sharp-internship)*


## Other Skills Learned
- Gained experience working with senior developers and management to identify bugs, recieve direction, and solve issues.
- Attained greater understanding of ASP.NET MVC, .NET Framework, and web-application development.
- Solving several diffcult tasks with no prior experience gave greater confidence in personal ability.

*Jump to: [Introduction](#introduction), [Home Page Styling](#home-page-styling), [Blog-Authors Stories](#blog-authors-stories), [Blog-Head Author Stories](#blog-head-author-stories), [Other Skills](#other-skills-learned), [Page Top](#c-sharp-internship)*
