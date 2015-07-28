using System;
using System.Web.Mvc;
using CodemashApp.Models;

namespace CodemashApp.Helpers.Html
{
    public static class SpeakerItemHelper
    {
        public static MvcHtmlString DisplaySocialIcons(this HtmlHelper helper, Speaker speaker)
        {
            if (speaker == null) return MvcHtmlString.Empty;

            var ul = new TagBuilder("ul");
            ul.AddCssClass("list-unstyled list-inline");

            var icons = AddSocialIcon(speaker.BlogUrl, "link").ToHtmlString() +
                        AddSocialIcon(speaker.GitHubLink, "github-square") +
                        AddSocialIcon(speaker.LinkedInProfile, "linkedin-square") +
                        AddSocialIcon(speaker.TwitterLink, "twitter-square");

            ul.InnerHtml = icons;

            return MvcHtmlString.Create(ul.ToString(TagRenderMode.Normal));
        }

        private static MvcHtmlString AddSocialIcon(string typeUrl, string faIcon)
        {
            if (String.IsNullOrEmpty(typeUrl)) return MvcHtmlString.Empty;

            var li = new TagBuilder("li");

            var anchor = new TagBuilder("a");
            anchor.Attributes.Add("href",typeUrl);
            anchor.Attributes.Add("title",typeUrl);
            
            var icon = new TagBuilder("i");
            icon.AddCssClass(String.Format("fa fa-{0} fa-3x", faIcon));

            anchor.InnerHtml = icon.ToString(TagRenderMode.Normal);

            li.InnerHtml = anchor.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(li.ToString(TagRenderMode.Normal));
        }
    }
}