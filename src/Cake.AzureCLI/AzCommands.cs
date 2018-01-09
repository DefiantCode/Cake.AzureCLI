namespace Cake.AzureCLI
{
    internal static class AzCommands
    {
        public const string Login = "login";

        internal static class Group
        { 
            public const string Create = "group create";
            public const string Delete = "group delete";
            public const string Exists = "group exists";

            internal static class Deployment
            {
                public const string Create = "group deployment create";
                public const string Validate = "group deployment validate";
            }
        }

        internal static class Aks
        {
            public const string Create = "aks create";
        }
    }
}
