# Microsoft NoSQL OpenHack artifacts

## Coaches: OpenHack classroom setup instructions

Follow the [deployment instructions](deployment-instructions.md) to prepare the classroom environment for an OpenHack event.

## Attendees: OpenHack artifacts

Feel free to use the below artifacts for your reference.

### Existing SQL database

Contoso Video has provided a database document for their current (test) Movies database. Each table contains a brief description and detailed schema information.

* [SQL database documentation](database-schema/README.md)
* [Database diagram](database-schema/database-diagram.png)

### Web application

Contoso Video uploaded a recent test build of their online video store and related projects. This has already been deployed to a web app running in your classroom Azure subscription. You can use this source code as a reference for determining query patterns and business logic. You will need [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) running on a Windows machine with [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472) in order to run it locally. Running it locally is optional, but could make the code evaluation process easier.

* [Visual Studio solution](Contoso.Apps.Movies.sln)

### Data generator

We have provided a data generator that orders on the website and pumps it into Azure Event Hubs. You will use this generator in some of the challenges, but it is a good idea to configure it beforehand. The data generator is deployed as a .NET Core 3.0 self-contained deployment (SCD) package. This means that the .NET Core runtime is included within each platform folder, so you do not need to download the .NET Core 3.0 SDK as a pre-requisite.

1. [Download the zip file](https://databricksdemostore.blob.core.windows.net/data/nosql-openhack/DataGenerator.zip) and extract it to your desktop.

2. Open the folder containing the extracted files, then open either the `linux-x64`, `osx-x64`, or `win-x64` subfolder, based on your environment.

3. Within the appropriate subfolder, open the **appsettings.json** file and update it with the following:

   * **EVENT_HUB_1_CONNECTION_STRING**: Open the Event Hubs namespace in the location 1 resource group (default name is `openhack1`), open the `telemetry` event hub, create a new shared access policy with both Send and Listen policies, and paste its connection string here.
   * **EVENT_HUB_2_CONNECTION_STRING**: Keep empty for now. This will need to be populated in a later challenge.
   * **SQL_CONNECTION_STRING**: The easiest way to retrieve this is to open the web app deployed to the location 1 resource group (`openhack1`), open **Configuration**, then copy the `SqlConnection` connection string value.

#### How to execute the data generator

When you need to execute the data generator, perform the following, based on your platform:

1. Windows:

   * Simply execute **DataGenerator.exe** inside the `win-x64` folder.

2. Linux:

   * Navigate to the `linux-x64` folder.
   * Run `chmod 777 DataGenerator` to provide access to the binary.
   * Run `./DataGenerator`.

3. MacOS:

   * Open a new terminal.
   * Navigate to the `osx-x64` directory.
   * Run `./DataGenerator`.
