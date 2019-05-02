using TechTalk.SpecFlow;
using Stylelabs.MQA.Core.Utilities;

namespace Stylelabs.MQA.TestCases.Steps
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeScenario]
        public static void BeforeScenario()
        {
            Installer.SetUpEnv();
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            Installer.CleanUpEnv();
        }
    }
}