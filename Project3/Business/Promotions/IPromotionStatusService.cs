using Project3.Models.Blocks;
using System;

namespace Project3.Business.Promotions
{
    public interface IPromotionStatusService
    {
        PromotionStatus GetStatus(PromotionBlock promotion, DateTime today);
    }
}
