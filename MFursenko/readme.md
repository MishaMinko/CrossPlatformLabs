### Створення пакету
1. Перенесіть код лабораторних робіт у бібліотеку класів `MFursenko`.
2. Спакуйте бібліотеку у NuGet пакет: `dotnet pack -o ./Packages`.
3. Додайте пакет до локального репозиторію: `nuget init ./Packages ./NuGetRepo`.

###
Оновлення пакету: `dotnet build --configuration Release`, `dotnet pack --configuration Release`.
Запушити зміни: `nuget push "bin\Release\MFursenko.1.0.2.nupkg" -Source "D:\+Univer\3-1\crossplatform\CrossPlatformLabs\MFursenko\NuGetRepo"`.
Перевірити: `nuget list MFursenko -Source "D:\+Univer\3-1\crossplatform\CrossPlatformLabs\MFursenko\NuGetRepo"`.

### Використання в консольному застосунку
1. Створіть консольний проєкт.
2. Додайте пакет: `dotnet add package MFursenko --version 1.0.2 --source "D:\+Univer\3-1\crossplatform\CrossPlatformLabs\MFursenko\NuGetRepo"`.
3. Використовуйте код лабораторних робіт у `Program.cs`.

### Запуск
1. Перейдіть до папки застосунку.
2. Виконайте `dotnet run`.