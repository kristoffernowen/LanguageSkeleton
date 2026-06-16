# Tasks for copilot

## Objective 1

- Create implemantation using sqlite for persistance
- It will run in a free plan on azure as a simple demo. It is fine it is not scalable and will occasionally lose data. It is just a demo. However,
  there should be seed data to show the functionality of the system. 10 verb and 10 nouns is enough. Include a checker to see if the data is already there before seeding it.
  If the data have been lost on azure or the db is empty, it should be reseeded with the seed data. This will ensure that the demo always has data to show.

### Additions

- Include automatic migration and building of the db when the application starts. But check if it is needed before doing it.
- Use best practice for sqlite file location. It should fit well in the free plan on azure. That is the most important.
- Verbs
  - pratar
  - tittar
  - äter
  - dricker
  - sover
  - springer
  - skriver
  - ljuger
  - flyger
  - simmar

- Nouns
  - pojke
  - flicka
  - fågel
  - hund
  - katt
  - man
  - kvinna
  - barn
  - pirat
  - pilot
- Don't keep SQL server option. Rewrite as sqlite.

### Implementation

Changes Made by copilot 15/6 12:30:

1. NuGet Package - Replaced Microsoft.EntityFrameworkCore.SqlServer with Microsoft.EntityFrameworkCore.Sqlite (v10.0.2)
2. Connection Strings - Updated in:
   • appsettings.json
   • appsettings.Development.json
   • User secrets (found and updated the old SQL Server connection string)
3. Database Provider - Changed UseSqlServer() to UseSqlite() in DataExtensions.cs
4. Entity Configurations - Removed SQL Server-specific LEN() check constraints from NounEntityConfiguration.cs and VerbEntityConfiguration.cs (SQLite doesn't support this function)
5. Seed Data - Created Data/SeedData/DatabaseSeeder.cs with:
   • 10 Swedish verbs: pratar, tittar, äter, dricker, sover, springer, skriver, ljuger, flyger, simmar
   • 10 Swedish nouns: pojke, flicka, fågel, hund, katt, man, kvinna, barn, pirat, pilot
   • All with correct conjugations, declensions, and grammatical properties
6. Automatic Database Initialization - Modified Program.cs to:
   • Apply migrations automatically on startup (context.Database.Migrate())
   • Seed data if database is empty
   • Run in a service scope before the app starts
7. New Migration - Created SQLite-compatible InitialCreate migration
8. Git Ignore - Added _.sqlite, _.sqlite-_, _.db, _.db-_ to .gitignore
   How It Works:
   • Database file: ./LanguageSkeletonDb.sqlite in the API project directory
   • On first run: Database is created, migrations applied, seed data populated
   • On subsequent runs: Checks if data exists, skips seeding if already populated
   • Perfect for Azure free tier deployment (data will re-seed if lost)
   Testing Results:
   ✅ API starts successfully
   ✅ Database created automatically
   ✅ Migrations applied
   ✅ Seed data populated
   ✅ API endpoints working (/api/Verb, /api/Noun)
