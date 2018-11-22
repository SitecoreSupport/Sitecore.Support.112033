using Sitecore.Marketing.Campaigns.Services.Attributes;
using Sitecore.Marketing.Campaigns.Services.Data;
using Sitecore.Marketing.Campaigns.Services.Model;
using Sitecore.Services.Core;
using Sitecore.Services.Core.ComponentModel.DataAnnotations;
using Sitecore.Services.Infrastructure.Services;
using Sitecore.Support.Marketing.Campaigns.Services.Filters;
using Sitecore.Web.Http.Filters;

namespace Sitecore.Support.Marketing.Campaigns.Services.Controllers
{
  [ServicesController("CampaignManagement.Campaign")]
  [ContextSiteSwitcherFilterAttribute(siteName: "cm_service")]
  [ArgumentExceptionFilter]
  [AccessDeniedExceptionFilter]
  [UnauthorizedAccessExceptionFilter]
  [ValidateHttpAntiForgeryToken]
  [SitecoreAuthorize(Roles = SitecoreAnalyticsMaintaining + "," + SitecoreAnalyticsReporting)]
  public class CampaignController : Sitecore.Marketing.Campaigns.Services.Controllers.CampaignController
  {
    const string SitecoreAnalyticsMaintaining = "sitecore\\Analytics Maintaining";

    const string SitecoreAnalyticsReporting = "sitecore\\Analytics Reporting";

    public CampaignController() : base()
    {
    }

    public CampaignController(IFilteredRepository<CampaignEntity> repository) : base(repository)
    {
    }

    public CampaignController(IFilteredRepository<CampaignEntity> repository, IMetaDataBuilder metadataBuilder, IEntityValidator entityValidator) : base(repository, metadataBuilder, entityValidator)
    {
    }
  }
}