# Sandbox
This project contains a collection of web pages 
demonstrating various UI idioms, widgets, APIs, etc 
that I commonly use in my various web development projects.

See http://johnatten.com/2014/04/06/asp-net-mvc-keep-private-settings-out-of-source-control/
for an outline of the technique used to exclude private app settings and connection
strings from GitHub.

To use features that require some sort of API key or database, you will need to 
get your own account and fill in the corresponding AppSettings in the Web.config 
file or create a PrivateSettings.config file from which the web.config file
will read the private settings.

Likewise, many features require a sample database to work with.  You
will need to create a database using your desired instance of SQL Server, then
run the script sandbox.sql from SqlServer Management Studio in a query window
opened to that database to create the database, then uncomment and modify the 
"DefaultConnection" connnection string in web.config to point to your database.
(Or create a ConnectionStrings.config file containing the connection string
definition).  
