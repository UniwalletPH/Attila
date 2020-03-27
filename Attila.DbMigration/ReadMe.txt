-- After modifying models from Attila.Domain.Entities
-- After applying configurations from Attila.Insfrastructure.Persistence.Configurations

1. Go to Package Manager Console
2. Set Default Project to Migrations\Attila.DbMigration

3. add-migration {name of your migration - eg. updated password column}
4. check connection string under appsettings.Development.json (Octans.UI)
5. update-database


if you will apply changes to production, update connection string from appsettings.Development.json (Octans.UI)
- update-database