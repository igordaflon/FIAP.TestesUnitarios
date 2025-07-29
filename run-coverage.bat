@echo off
REM 1. Apagar a pasta coverage-report, se existir
if exist coverage-report (
    rmdir /s /q coverage-report
)

REM 2. Apagar o conteúdo da pasta TestResults
if exist src\FIAP.TestesUnitarios.Dominio.Testes\TestResults (
    del /q /f src\FIAP.TestesUnitarios.Dominio.Testes\TestResults\*
    for /d %%i in (src\FIAP.TestesUnitarios.Dominio.Testes\TestResults\*) do rmdir /s /q "%%i"
)

REM 3. Rodar os testes com cobertura
dotnet test src\FIAP.TestesUnitarios.Dominio.Testes --no-build --collect:"XPlat Code Coverage" -- DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Include="[FIAP.TestesUnitarios.Dominio*]*"
if errorlevel 1 (
    echo Testes falharam. Abortando.
    exit /b 1
)

REM 4. Gerar o relatório HTML (procura o coverage.cobertura.xml mais recente)
setlocal enabledelayedexpansion
for /f "delims=" %%f in ('dir /b /s /o-d src\FIAP.TestesUnitarios.Dominio.Testes\TestResults\coverage.cobertura.xml') do (
    set "COVPATH=%%f"
    if exist "!COVPATH!" (
        reportgenerator -reports:"!COVPATH!" -targetdir:coverage-report -reporttypes:Html
        goto :EOF
    )
)
endlocal

echo coverage.cobertura.xml não encontrado!
exit /b 1
