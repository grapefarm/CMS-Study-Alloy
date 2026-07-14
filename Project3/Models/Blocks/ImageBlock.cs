using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace Project3.Models.Blocks
{
    [ContentType(
        DisplayName = "自訂圖片元件",
        GUID = "A67D0B93-8F74-4C3D-9A6B-9876543210AB", // 這是這支 Block 的身分證，必須是唯一值
        Description = "用來顯示單張圖片與替代文字的元件",
        GroupName = SystemTabNames.Content)]
    public class ImageBlock : SiteBlockData
    {
        [CultureSpecific] // 代表這個欄位支援多國語系
        [Display(
            Name = "圖片上傳",
            Description = "請從媒體庫選擇或上傳一張圖片",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [UIHint(UIHint.Image)] // 關鍵！告訴後台這不是一般的文字，這是一個「圖片選擇器」
        public virtual ContentReference ImageUrl { get; set; } // 用 ContentReference 來存圖片的內部 ID

        [CultureSpecific]
        [Display(
            Name = "圖片替代文字 (AltText)",
            Description = "SEO 與無障礙網頁必填的圖片說明",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual string AltText { get; set; }
    }
}
