$migrationName = $args[0]

dotnet ef migrations add $migrationName -c DataContext -o Migrations -p ..\GleamAPI.Data\ -s ..\GleamAPI\