#r "../../src/Cake.AzureCLI/bin/Debug/netstandard1.6/Cake.AzureCLI.dll"

///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var rgName = Argument("rg-name", "RG-JS-TEST01");
var rgLocation = Argument("rg-location", "centralus");
var azUsername = EnvironmentVariable("az_username");
var azPassword = EnvironmentVariable("az_password");

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(ctx =>
{
    Information("Attempting to login to Azure...");
    ctx.AzLogin(azUsername, azPassword);
    Information("Login successful");
});

Teardown(ctx =>
{
   
});

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////


Task("Default")
.IsDependentOn("CreateGroup")
.IsDependentOn("DeleteGroup");

Task("CreateGroup")
    .WithCriteria(() => !AzGroupExists(rgName))
    .Does(() =>
{
    Information("Attempting to create resource group '{0}' in '{1}'...", rgName, rgLocation);    
    AzGroupCreate(rgName, rgLocation);
    Information("Successfully created resource group '{0}' in '{1}'...", rgName, rgLocation);    
});

Task("DeleteGroup")
    .WithCriteria(() => AzGroupExists(rgName))
    .Does(() =>
{
    Information("Attempting to delete resource group '{0}'...", rgName);    
    AzGroupDelete(rgName);
    Information("Successfully deleted resource group '{0}'", rgName);    
});

RunTarget(target);