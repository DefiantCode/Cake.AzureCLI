namespace Cake.AzureCLI.Login
{
    public class AzLoginSettings : AzSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Tenant { get; set; }
        public bool ServicePrincipal { get; set; }
    }
}
