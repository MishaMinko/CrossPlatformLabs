Лаби працюють, треба накатити бібліотеку MFursenko командою `dotnet add package MFursenko --version 1.0.2 --source "D:\+Univer\3-1\crossplatform\CrossPlatformLabs\MFursenko\NuGetRepo"`
При вході в акаунт постійно вилітає помилка в консолі:
Authorization Code Received
Remote failure: OpenIdConnectAuthenticationHandler: message.State is null or empty.
При цьому вхід в акаунт здійснюється успішно. Дані для входу:
admin@admin.com
im1Admin111

можна зареєструвати нового користувача і відразу ввійти в акаунт - буде помилка але далі працюватиме наче нічого і немає

при виході з акаунта виходить без проблем, кукі я поставив зберігається 1 хв у сервісі Auth0

у Linux треба прописати в проєкті Lab13 команду: `dotnet add package MFursenko --version 1.0.2 --source "/home/vagrant/project/MFursenko/NuGetRepo"`
після цього у папці Lab прописати `dotnet run`
сайт буде доступний за посиланням: http://192.168.56.10:5145/