# Copilot Instructions

## Project Guidelines
- I moduliserade projekt (Customers, Employees) ska varje modul ha sin egen IDesignTimeDbContextFactory som läser connection string från modulens egna UserSecretsId/appsettings.json, så att 'dotnet ef migrations add/update-database' kan köras direkt mot respektive modulprojekt utan --startup-project.

## Code Movement Guidelines
- Gör aldrig mer än vad som uttryckligen begärs. Om användaren ber om att "flytta" kod, ska det göras som en ren flytt/kopiering utan samtidig omskrivning till andra mönster, arkitekturer eller felhanteringsstrategier (t.ex. FastEndpoints Command Bus vs. egna interfaces, Result<T> vs. throw). Eventuella förbättringar eller mönsterändringar ska föreslås separat och endast genomföras efter explicit godkännande.