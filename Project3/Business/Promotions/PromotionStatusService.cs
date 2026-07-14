using Project3.Models.Blocks;
using System;

namespace Project3.Business.Promotions
{
    /// <summary>
    /// Contains the date rules for a promotion. It has no CMS or HTTP dependency,
    /// so the rules can be unit-tested without running the website.
    /// </summary>
    public class PromotionStatusService : IPromotionStatusService
    {
        private const int EndingSoonThresholdInDays = 7;

        public PromotionStatus GetStatus(PromotionBlock promotion, DateTime today)
        {
            var currentDate = today.Date;

            if (promotion.CampaignStartDate.HasValue && promotion.CampaignStartDate.Value.Date > currentDate)
            {
                return PromotionStatus.Scheduled;
            }

            if (promotion.CampaignEndDate.HasValue)
            {
                var endDate = promotion.CampaignEndDate.Value.Date;

                if (endDate < currentDate)
                {
                    return PromotionStatus.Expired;
                }

                if (endDate <= currentDate.AddDays(EndingSoonThresholdInDays))
                {
                    return PromotionStatus.EndingSoon;
                }
            }

            return PromotionStatus.Active;
        }
    }
}
