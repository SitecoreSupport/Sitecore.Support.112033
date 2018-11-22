using Sitecore.Marketing.Definitions.Campaigns;
using Sitecore.Sites;

namespace Sitecore.Support.Marketing.Campaigns.Services
{
  public class ExperienceAnalyticsLinkBuilder : Sitecore.Marketing.Campaigns.Services.ExperienceAnalyticsLinkBuilder
  {
    [CanBeNull]
    string _contextSiteName;

    public ExperienceAnalyticsLinkBuilder([CanBeNull] string contextSiteName)
    {
      _contextSiteName = contextSiteName;
    }
    public override string GetReportLink(ICampaignActivityDefinition campaignActivityDefinition)
    {
      if (string.IsNullOrEmpty(_contextSiteName))
      {
        return base.GetReportLink(campaignActivityDefinition);
      }

      // To minimize overriden code
      using (new SiteContextSwitcher(SiteContextFactory.GetSiteContext(_contextSiteName)))
      {
        return base.GetReportLink(campaignActivityDefinition);
      }
    }

    protected virtual SiteContext GetSiteContext()
    {
      return SiteContextFactory.GetSiteContext(_contextSiteName);
    }
  }
}