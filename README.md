# Documentation for Accessing User Details via a GitHub API

This is a simple web application that allows users to search for GitHub users and view their top five repositories. The application is built using MVC Architecture in .NET Core and utilizes the GitHub API to fetch user data.

## Details

You can view the user's name, location, avatar image and their top five repositories based on the stargazer count.

## Steps
1. When you run the application, you will encounter a basic page that has a Username field and a Submit button.
2. Enter a username of a GitHub account that exists or doesn't exist, then click Submit.
3. If it exists, details will appear on the next page.
4. You can click on the Repository Name to be re-directed to that GitHub Repository.
5. Click 'Go Back' at the bottom to return to the first page.

## Running the Application

In your terminal, run the command:

```
dotnet watch --no-hot-reload run --project github-users-repo-web-app
```
