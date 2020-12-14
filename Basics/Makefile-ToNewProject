# Project Variables
name ?= DotNetApp

.PHONY: echo create test

echo:
	echo "Hello, World!"

create:
	dotnet new sln -n $(name)
	dotnet new classlib -o $(name)
	dotnet sln add ./$(name)
	dotnet new xunit -o $(name).Tests
	dotnet sln add ./$(name).Tests
	dotnet add ./$(name).Tests reference ./$(name)
	dotnet add $(name).Tests package coverlet.msbuild

test:
	dotnet test /p:CollectCoverage=true
