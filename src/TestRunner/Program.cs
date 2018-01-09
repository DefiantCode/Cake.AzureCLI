using Cake.AzureCLI;
using Cake.AzureCLI.Group;
using Cake.Core;
using Cake.Core.IO;
using System;
using System.Text.RegularExpressions;

namespace TestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ProcessArgumentBuilder();

            //var settings = new { Location = "uswest1", Name = "myRG", Verbose = true, SomethingLongHere = "booooo" };
            var settings = new TestClass { MyProperty = "use as argument", MyOtherProperty = "ignore" };
            ToolArgumentAttribute.PopulateArguments(builder, settings, true);

            builder.Append("group create");
            Console.WriteLine(builder.Render());

            //var input = "Name";

            ////var output = Regex.Replace(input, "([A-Z])", "-$1", RegexOptions.Compiled).Trim().ToLower();
            //var output = Regex.Replace(input, "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", "-$1").ToLower();
            //Console.WriteLine(output);
        }
    }

    class TestClass
    {
        public string MyProperty { get; set; }
        [ToolArgument(true)]
        public string MyOtherProperty { get; set; }
    }
}
