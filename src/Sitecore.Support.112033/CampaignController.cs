using Sitecore.Marketing.Campaigns.Services.Attributes;
using Sitecore.Marketing.Campaigns.Services.Data;
using Sitecore.Marketing.Campaigns.Services.Model;
using Sitecore.Services.Core;
using Sitecore.Services.Core.ComponentModel.DataAnnotations;
using Sitecore.Services.Infrastructure.Services;
using Sitecore.Support.Marketing.Campaigns.Services.Filters;
using Sitecore.Web.Http.Filters;
using System.Reflection;

using CampaignRepositoryType = Sitecore.Marketing.Campaigns.Services.Data.CampaignRepository;

namespace Sitecore.Support.Marketing.Campaigns.Services.Controllers
{
  [ServicesController("CampaignManagementSupport.Campaign")]
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

    const string EASiteName = "website";

    readonly static PropertyInfo _mLinkBuilder = typeof(CampaignRepositoryType)
        .GetProperty("LinkBuilder", BindingFlags.NonPublic | BindingFlags.Instance);

    public CampaignController() : base()
    {
      Init();
    }

    public CampaignController(IFilteredRepository<CampaignEntity> repository) : base(repository)
    {
      Init();
    }

    public CampaignController(IFilteredRepository<CampaignEntity> repository, IMetaDataBuilder metadataBuilder, IEntityValidator entityValidator) : base(repository, metadataBuilder, entityValidator)
    {
      Init();
    }

    void Init()
    {
      var campaignRepository = Repository as CampaignRepositoryType;

      if (campaignRepository == null)
      {
        return;
      }

      _mLinkBuilder.SetValue(campaignRepository, new ExperienceAnalyticsLinkBuilder(EASiteName));
    }
  }
}