# ASPNETMVCCoreTest
Test application setup for use with MySql.Data.EntityFrameworkCore, ASP.NET Identity and IdentityServer4

# Setup / Configuration Notes

Important step to configuring ASP.NET Identity, IdentityServer4, MySQL is to create the migrations as outlined here:

http://docs.identityserver.io/en/release/quickstarts/8_entity_framework.html

The two migration steps are about halfway down the page:

# Migration for PersistedGrantDbContext:

dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb

# Migration for ConfigurationDbContext:

dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb


