using EPiServer.Core;
using EPiServer.Web;
using Microsoft.AspNetCore.Html;
using Project3.Models.Pages;
using System.ComponentModel.DataAnnotations;

namespace Project3.Models.ViewModels
{
    public class ContactBlockModel
    {
        [UIHint(UIHint.Image)]
        public ContentReference Image { get; set; }

        public string Heading { get; set; }

        public string LinkText { get; set; }

        public IHtmlContent LinkUrl { get; set; }

        public bool ShowLink { get; set; }

        public ContactPage ContactPage { get; set; }
    }
}
