using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Sitecore.Configuration;
using Sitecore.Diagnostics;
using Sitecore.Sites;

namespace Sitecore.Support.Marketing.Campaigns.Services.Filters
{
    internal sealed class ContextSiteSwitcherFilterAttributeAttribute : ActionFilterAttribute
    {
        [NotNull]
        readonly string _siteName;

        public ContextSiteSwitcherFilterAttributeAttribute([NotNull] string siteName)
        {
            Assert.ArgumentNotNullOrEmpty(siteName, nameof(siteName));

            _siteName = siteName;
        }

        public override void OnActionExecuting(HttpActionContext filterContext) =>
            SiteContextSwitcher.Enter(Factory.GetSite(_siteName));


        public override void OnActionExecuted(HttpActionExecutedContext filterContext) =>
            SiteContextSwitcher.Exit();
    }
}