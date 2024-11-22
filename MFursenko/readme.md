### ��������� ������
1. ��������� ��� ������������ ���� � �������� ����� `MFursenko`.
2. �������� �������� � NuGet �����: `dotnet pack -o ./Packages`.
3. ������� ����� �� ���������� ����������: `nuget init ./Packages ./NuGetRepo`.

###
��������� ������: `dotnet build --configuration Release`, `dotnet pack --configuration Release`.
�������� ����: `nuget push "bin\Release\MFursenko.1.0.2.nupkg" -Source "D:\+Univer\3-1\crossplatform\CrossPlatformLabs\MFursenko\NuGetRepo"`.
���������: `nuget list MFursenko -Source "D:\+Univer\3-1\crossplatform\CrossPlatformLabs\MFursenko\NuGetRepo"`.

### ������������ � ����������� ����������
1. ������� ���������� �����.
2. ������� �����: `dotnet add package MFursenko --version 1.0.2 --source "D:\+Univer\3-1\crossplatform\CrossPlatformLabs\MFursenko\NuGetRepo"`.
3. �������������� ��� ������������ ���� � `Program.cs`.

### ������
1. �������� �� ����� ����������.
2. ��������� `dotnet run`.