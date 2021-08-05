Для создания миграции в Package Manager Console выполнить, выбрав дефолтный проект инфраструктуры
add-migration -Name "MigrationName" -OutputDir "DatabaseContext/Migrations"

Для создания базы данных и схемы из миграции выполнить
Update-Database