# nosql-openhack

## Deploy Web App To Azure Using GitHub repository

<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fsolliancenet%2Fnosql-openhack%2Fmaster%2Fazuredeploy.json" rel="nofollow">
    <img src="https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/1-CONTRIBUTION-GUIDE/images/deploytoazure.png" style="max-width:100%;">
</a>

## PowerShell instructions

1. Open a **PowerShell ISE** window, run the following command, if prompted, click **Yes to All**:

   ```PowerShell
   Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
   ```

2. Make sure you have the latest PowerShell Azure module installed by executing the following command:

    ```PowerShell
    Install-Module -Name Az -AllowClobber -Scope CurrentUser
    ```

3. If you installed an update, **close** the PowerShell ISE window, then **re-open** it. This ensures that the latest version of the Az module is used.

4. Execute the following to sign in to the Azure account:

    ```PowerShell
    Connect-AzAccount
    ```

5. Open the `deploy.ps1` PowerShell script in the PowerShell ISE window.