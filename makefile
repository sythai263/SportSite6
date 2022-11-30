up:
	docker-compose up -d
down:
	docker-compose down
dbmigrate:
	dotnet ef database update
dbgenerate:
	dotnet ef migrations add $(name)
watch:
	dotnet watch run