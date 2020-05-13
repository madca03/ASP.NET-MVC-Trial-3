# ASP.NET-MVC-Trial-3
RESTful CRUD App Single Resource

## Notes for Local IIS deployment
1. Enable local IIS feature in your Windows machine. This [link](https://www.youtube.com/watch?v=PPaqVyBkwMk) shows how to setup your local IIS on your Windows machine
as well as on how to publish your ASP.NET MVC web application on your local IIS
2. If you are using Entity framework and Microsoft SQL Server, you may encounter problems on database authentication when you're
browsing / fetching your RESTful API routes such as this one:
![alt text](https://github.com/madca03/ASP.NET-MVC-Trial-3/blob/master/images/error-in-local-iis-db-auth.png "Error in query")

See the solution in these two links on how to resolve this issue:
- [Link 1](https://stackoverflow.com/questions/7698286/login-failed-for-user-iis-apppool-asp-net-v4-0)
- [Link 2](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/ms189121(v=sql.105)?redirectedfrom=MSDN)

3. With the ASP.NET MVC app deployed on your local IIS server, you can now test your RESTful routes using [Postman](https://www.postman.com/)