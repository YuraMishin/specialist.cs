# Project Variables
name ?= DotNetApp

.PHONY: echo create test

echo:
	echo "Hello, World!"

create:
	dotnet new sln -n $(name)
	dotnet new console -o ./src/$(name).App
	dotnet sln add ./src/$(name).App
	dotnet new classlib -o ./src/$(name).Classes
	dotnet sln add ./src/$(name).Classes
	dotnet add ./src/$(name).App reference ./src/$(name).Classes
	dotnet new xunit -o ./tests/$(name).UnitTests
	dotnet sln add ./tests/$(name).UnitTests
	dotnet add ./tests/$(name).UnitTests reference ./src/$(name).Classes
	dotnet add ./tests/$(name).UnitTests package coverlet.msbuild
	dotnet add ./tests/$(name).UnitTests package FluentAssertions

test:
	dotnet test /p:CollectCoverage=true

add-migration:
	dotnet ef migrations add $(name) --project .\src\EFPostgrsql.App

remove:
	dotnet ef migrations remove --project .\src\EFPostgrsql.App

clean:
	dotnet ef database update 0 --project .\src\EFPostgrsql.App

up:
	dotnet ef database update --project .\src\EFPostgrsql.App

back:
	dotnet ef database update ${name} --project .\src\EFPostgrsql.App
