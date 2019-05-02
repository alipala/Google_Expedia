using Stylelabs.MQA.Core;

namespace Stylelabs.MQA.PageElements.Pages
{
    public abstract class PageBase
    {
        private string _loadUrl;

        protected PageBase(string loadUrl = "")
        {
            this._loadUrl = loadUrl;
        }

        public void NavigateTo()
        {
            Base.Driver.Navigate().GoToUrl(_loadUrl);
        }
    }
}
