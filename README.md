# isb-tech-test

Versions:

- Angular v17
- .Net Core v8

How to run the project:

- Update your connection string in `appsettings.Development.json`

- Run migration script `dotnet ef database update -p ISBTest.DAL -s ISBTest.WebApi -c ISBTestDbContext`

- Open `ISBTest.WebApi.sln` solution, make sure the `ISBTest.WebApi` is startup project, then run the api.

- Start Angular app from `isb-tech-test\angular-app` folder.

NOTE:

- The project start with some seeding data, but only the first property got some ownership changes.

- You can use the Swagger (should be started when starting the api) to add more ownership changes or more properties to test.
