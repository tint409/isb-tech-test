# isb-tech-test

How to run the project:

Update your connection string in `appsettings.Development.json`

Run migration script `dotnet ef database update -p ISBTest.DAL -s ISBTest.WebApi -c ISBTestDbContext`
