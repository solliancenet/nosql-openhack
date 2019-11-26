# Enter the first Resource Group name (i.e. openhack1)
$resourceGroup1Name = "openhack3"
# Enter the second Resource Group name (i.e. openhack2)
$resourceGroup2Name = "openhack4"
# Enter the location for the first resource group (i.e. westus)
$location1 = "westus2"
# Enter the location for the second resource group (i.e. eastus)
$location2 = "eastus"
# Enter the SQL Server username (i.e. openhackadmin)
$sqlAdministratorLogin = "openhackadmin"
# Enter the SQL Server password (i.e. Password123)
$sqlAdministratorLoginPassword = "Password123"

$databaseName = "Movies"

New-AzResourceGroup -Name $resourceGroup1Name -Location $location1
New-AzResourceGroup -Name $resourceGroup2Name -Location $location2

$templateUri = "https://raw.githubusercontent.com/solliancenet/nosql-openhack/master/azuredeploy.json"

$outputs = New-AzResourceGroupDeployment `
    -ResourceGroupName $resourceGroup1Name `
    -TemplateUri $templateUri `
    -secondResourceGroup $resourcegroup2Name `
    -secondLocation $location2 `
    -sqlAdministratorLogin $sqlAdministratorLogin `
    -sqlAdministratorLoginPassword $(ConvertTo-SecureString -String $sqlAdministratorLoginPassword -AsPlainText -Force)

$sqlSvrFqdn = $outputs.Outputs["sqlSvrFqdn"].value
$sqlserverName = $outputs.Outputs["sqlserverName"].value

$importRequest = New-AzSqlDatabaseImport -ResourceGroupName "<resourceGroupName>" `
    -ServerName $sqlserverName -DatabaseName $databaseName `
    -DatabaseMaxSizeBytes "5368709120" `
    -StorageUri "https://myStorageAccount.blob.core.windows.net/importsample/sample.bacpac" `
    -Edition "Basic" -ServiceObjectiveName "Basic" `
    -AdministratorLogin $sqlAdministratorLogin `
    -AdministratorLoginPassword $(ConvertTo-SecureString -String $sqlAdministratorLoginPassword -AsPlainText -Force)

$importStatus = Get-AzSqlDatabaseImportExportStatus -OperationStatusLink $importRequest.OperationStatusLink

[Console]::Write("Importing database")
while ($importStatus.Status -eq "InProgress") {
    $importStatus = Get-AzSqlDatabaseImportExportStatus -OperationStatusLink $importRequest.OperationStatusLink
    [Console]::Write(".")
    Start-Sleep -s 10
}

[Console]::WriteLine("")
$importStatus