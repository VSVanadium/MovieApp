# Movie App
A Console app using enitify framework core.  

Please make sure you have all necessary nuget pacakges installed.

Follow the following basic commands and steps, if you are new to entity framework.


The project connect on microsoft SQL database installed locally on the machine. Set the connection string for the database(where ActorDB is the name of the database) under visual studio powershell terminal below by running the following command:
```cmd
dotnet user-secrets set ConnectionStrings:DefaultConnection "Server=localhost\SQLEXPRESS;Database=ActorDB;Trusted_Connection=True;TrustServerCertificate=True"
```

The following will add the migration folder in your project
```cmd
dotnet ef migrations add initialCreate
```

To create the database, run the following commnad:
```cmd
dotnet ef  migrations add CreateDatabase
```

Now, run
```cmd
dotnet ef database update
```

Go check in the Microsoft SQL management studio, a database with name ActorDB should be created, note: table are created without any data.

Finally, run the program.cs. This will insert a movie record, two actors in the table and fetches and display on the console window.

Everytime, you make changes to the entities, create new ones, just add new migration using add-migration command and providing unique name <migration-name> to the migration script: e.g.
```cmd
dotnet ef  migrations add <migration-name>
```

Note: if your project has more than one database context, mention the context along with the command:
```cmd
dotnet ef  migrations add <migration-name> --context <database-context-name>
```

and then execute to apply migration to the database
```cmd 
dotnet ef database update
``` 

You can revert migration, by providing the last valid migration name.
```cmd
dotnet ef database update <migration-name>
```
or you can remove the last migration using command:
```cmd
dotnet ef migrations remove
```
