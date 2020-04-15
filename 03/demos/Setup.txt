To setup the database for the demos, do the following:
1. Open the ZzaDatabase.sql file from the root folder for the demos in Visual Studio
2. Click the Execute button in the upper left of the editor window for the SQL file.
3. In the Connect dialog that comes up, expand the Local node in the tree, and select MSSQLLocalDB.
4. Click the Connect button at the bottom.
5. The script should run, creating the database with the appropriate schema and sample data.

To run the solutions in this folder:
1. Open the solution in Visual Studio.
2. Right click on the solution root node and select "Manage Nuget Packages for Solution..."
3. A yellow bar should be present at the top of that view with a Restore button, click that to restore nuget packages.
4. Build and run.