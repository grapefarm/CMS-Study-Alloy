using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using System;
using System.ComponentModel.DataAnnotations;

namespace Project3.Models.Blocks
{
    /// <summary>
    /// A reusable promotion card that editors can place in any ContentArea.
    /// </summary>
    [SiteContentType(
        GUID = "D47EE960-48B2-4A73-9FCE-10739C0DD1A7",
        DisplayName = "促銷卡片",
        Description = "顯示圖片、文案與行動按鈕的可重複使用元件")]
    [SiteImageUrl]
    public class PromotionBlock : SiteBlockData
    {
        [CultureSpecific]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "標題", GroupName = SystemTabNames.Content, Order = 10)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(Name = "活動開始日", GroupName = SystemTabNames.Content, Order = 15)]
        public virtual DateTime? CampaignStartDate { get; set; }

        [CultureSpecific]
        [Display(Name = "活動結束日", Description = "未填寫代表不設定結束時間", GroupName = SystemTabNames.Content, Order = 16)]
        public virtual DateTime? CampaignEndDate { get; set; }

        [CultureSpecific]
        [Display(Name = "內文", GroupName = SystemTabNames.Content, Order = 20)]
        public virtual XhtmlString Body { get; set; }

        [CultureSpecific]
        [UIHint(UIHint.Image)]
        [Display(Name = "圖片", GroupName = SystemTabNames.Content, Order = 30)]
        public virtual ContentReference Image { get; set; }

        [CultureSpecific]
        [Display(Name = "圖片替代文字", Description = "供螢幕閱讀器與圖片無法載入時使用", GroupName = SystemTabNames.Content, Order = 40)]
        public virtual string ImageAltText { get; set; }

        [CultureSpecific]
        [Display(Name = "按鈕文字", GroupName = SystemTabNames.Content, Order = 50)]
        public virtual string ButtonText { get; set; }

        [Display(Name = "按鈕連結", GroupName = SystemTabNames.Content, Order = 60)]
        public virtual Url ButtonLink { get; set; }
    }
}
