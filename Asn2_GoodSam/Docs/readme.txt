﻿enable-migrations -ContextTypeName TempPwdContext -MigrationsDirectory Migrations\TempPwdMigrations

add-migration -ConfigurationTypeName Asn2_GoodSam.Migrations.TempPwdMigrations.Configuration "InitialCreate"

update-database -ConfigurationTypeName Asn2_GoodSam.Migrations.ClientMigrations.Configuration
