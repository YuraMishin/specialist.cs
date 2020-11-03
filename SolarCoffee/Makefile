# Project Variables
PROJECT_NAME ?= SolarCoffee
ORG_NAME ?= SolarCoffee
REPO_NAME ?= SolarCoffee

.PHONY: echo migrations db

echo:
	echo "Hello, World!"

migrations:
	cd ./SolarCoffee.Data && dotnet ef --startup-project ../SolarCoffee.Web/ migrations add $(mname) && cd ..

db:
	cd ./SolarCoffee.Data && dotnet ef --startup-project ../SolarCoffee.Web/ database update && cd ..
