# Library 2024 - MVC Project with EF
MVC design of a website for a public library to manage current offers.

1. Project designed according to the MVC pattern
2. Database connection chain:
   "ConnectionStrings": {"DefaultConnection": "Server=.;Database=LibraryWeb2024;Trusted_Connection=True;TrustServerCertificate=True"}
3. The library design supports the creation of users whose roles can be freely selected during the account creation process.
4. The administrator role allows you to add, delete, and edit existing categories.
5. The logged in user role allows you to place an order using the "ask for availability" button in the offer details tab.

INSTALLATION:
Installing the project is very simple:
1. Clone/download the repository from github
2. Open the NuGet package management manager and enter the command: "database-update" to create a default database (The application has the necessary migrations configured and described, so creating them will not be necessary).
3. We launch the project
