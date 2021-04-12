using FeGv3.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//this is a disaster and i need to learn how to do this better
namespace FeGv3.Infrastructure
{
    //create a pagination class
    [HtmlTargetElement("div", Attributes = "page-info")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory _UrlHelper; //this helps to build routes
        //trying to not have a million pages
        //public int PageNum;

        public PaginationTagHelper(IUrlHelperFactory uhf) //create a constructor
        {
            _UrlHelper = uhf;
            //attempting to modify the constructor
            //PageNum = pageNum;
        }

        public static void CreateEllipsis(TagBuilder outputTag)
        {
            for (int i = 0; i < 3; i++)
            {
                TagBuilder link = new TagBuilder("a");

                link.Attributes["href"] = "";
                link.Attributes["disabled"] = true.ToString();
                link.InnerHtml.AppendHtml(".");

                outputTag.InnerHtml.AppendHtml(link);
            }
        }        

        public PaginationModel PageInfo { get; set; }

        //dictionary to hold the strings for our urls
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")] //must be "page-url-"
        public Dictionary<string, object> KeyValuePairs { get; set; } = new Dictionary<string, object>();

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext vc { get; set; }

        //classes for the link tags//
        //This is the page data for the page that is selected
        public string pageClassSelected { get; set; }
        //this is the page data for the regular non-selected pages
        public string pageClassNormal { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper UrlHelp = _UrlHelper.GetUrlHelper(vc);

            TagBuilder outputTag = new TagBuilder("div");
            TagBuilder previous = new TagBuilder("a");
            TagBuilder nextItem = new TagBuilder("a");

            KeyValuePairs["pageNum"] = PageInfo.CurrPage - 1;
            previous.Attributes["href"] = UrlHelp.Action("Index", KeyValuePairs);
            previous.InnerHtml.AppendHtml("Previous");
            previous.AddCssClass(pageClassNormal);

            KeyValuePairs["pageNum"] = PageInfo.CurrPage + 1;
            nextItem.Attributes["href"] = UrlHelp.Action("Index", KeyValuePairs);
            nextItem.InnerHtml.AppendHtml("Next");
            nextItem.AddCssClass(pageClassNormal);

            //lots of conditionals: if the current page is <= 2, then we generate the first three pages and then an ellipsis and then the last two pages
            //if it's less than the number of pages - 3 and greater than 2, then we generate three pages starting at the current page-1 and up to the last two pages
            //if it's greater than the number of pages - 3 then we generate the first page and the last four pages        
            if (PageInfo.Pages > 10)
            {
                if (PageInfo.CurrPage <= 4 && PageInfo.CurrPage < PageInfo.Pages - 3)
                {
                    outputTag.InnerHtml.AppendHtml(previous);

                    if (PageInfo.CurrPage < 2)
                    {
                        for (int i = 1; i <= PageInfo.CurrPage + 2; i++) // was originally int i = 1; i <= PageInfo.Pages;              
                        {
                            TagBuilder link = new TagBuilder("a");

                            KeyValuePairs["pageNum"] = i;

                            link.Attributes["href"] = UrlHelp.Action("Index", KeyValuePairs);
                            link.InnerHtml.AppendHtml(i.ToString());
                            link.AddCssClass(i == PageInfo.CurrPage ? pageClassSelected : pageClassNormal);

                            outputTag.InnerHtml.AppendHtml(link);
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= PageInfo.CurrPage + 1; i++) // was originally int i = 1; i <= PageInfo.Pages;              
                        {
                            TagBuilder link = new TagBuilder("a");

                            KeyValuePairs["pageNum"] = i;

                            link.Attributes["href"] = UrlHelp.Action("Index", KeyValuePairs);
                            link.InnerHtml.AppendHtml(i.ToString());
                            link.AddCssClass(i == PageInfo.CurrPage ? pageClassSelected : pageClassNormal);

                            outputTag.InnerHtml.AppendHtml(link);
                        }
                    }

                    CreateEllipsis(outputTag);

                    TagBuilder lastPage = new TagBuilder("a");

                    KeyValuePairs["pageNum"] = PageInfo.Pages;

                    lastPage.Attributes["href"] = UrlHelp.Action("Index", KeyValuePairs);
                    lastPage.InnerHtml.AppendHtml(PageInfo.Pages.ToString());
                    lastPage.AddCssClass(PageInfo.Pages == PageInfo.CurrPage ? pageClassSelected : pageClassNormal);

                    outputTag.InnerHtml.AppendHtml(lastPage);

                    outputTag.InnerHtml.AppendHtml(nextItem);
                }
                else if (PageInfo.CurrPage > 4 && PageInfo.CurrPage < PageInfo.Pages - 3)
                {
                    outputTag.InnerHtml.AppendHtml(previous);

                    TagBuilder firstPage = new TagBuilder("a");

                    KeyValuePairs["pageNum"] = 1;

                    firstPage.Attributes["href"] = UrlHelp.Action("Index", KeyValuePairs);
                    firstPage.InnerHtml.AppendHtml("1");
                    firstPage.AddCssClass(pageClassNormal);

                    outputTag.InnerHtml.AppendHtml(firstPage);

                    CreateEllipsis(outputTag);

                    for (int i = PageInfo.CurrPage - 1; i <= PageInfo.CurrPage + 1; i++)
                    {
                        TagBuilder link = new TagBuilder("a");

                        KeyValuePairs["pageNum"] = i;

                        link.Attributes["href"] = UrlHelp.Action("Index", KeyValuePairs);
                        link.InnerHtml.AppendHtml(i.ToString());
                        link.AddCssClass(i == PageInfo.CurrPage ? pageClassSelected : pageClassNormal);

                        outputTag.InnerHtml.AppendHtml(link);
                    }

                    CreateEllipsis(outputTag);

                    TagBuilder lastPage = new TagBuilder("a");

                    KeyValuePairs["pageNum"] = PageInfo.Pages;

                    lastPage.Attributes["href"] = UrlHelp.Action("Index", KeyValuePairs);
                    lastPage.InnerHtml.AppendHtml(PageInfo.Pages.ToString());
                    lastPage.AddCssClass(PageInfo.Pages == PageInfo.CurrPage ? pageClassSelected : pageClassNormal);

                    outputTag.InnerHtml.AppendHtml(lastPage);

                    outputTag.InnerHtml.AppendHtml(nextItem);
                }
                else if (PageInfo.CurrPage >= PageInfo.Pages - 3)
                {
                    outputTag.InnerHtml.AppendHtml(previous);

                    TagBuilder firstPage = new TagBuilder("a");

                    KeyValuePairs["pageNum"] = 1;

                    firstPage.Attributes["href"] = UrlHelp.Action("Index", KeyValuePairs);
                    firstPage.InnerHtml.AppendHtml("1");
                    firstPage.AddCssClass(pageClassNormal);

                    outputTag.InnerHtml.AppendHtml(firstPage);

                    CreateEllipsis(outputTag);
                    if (PageInfo.CurrPage >= PageInfo.Pages - 1)
                    {
                        for (int i = PageInfo.CurrPage - 2; i <= PageInfo.Pages; i++)
                        {
                            TagBuilder link = new TagBuilder("a");

                            KeyValuePairs["pageNum"] = i;

                            link.Attributes["href"] = UrlHelp.Action("Index", KeyValuePairs);
                            link.InnerHtml.AppendHtml(i.ToString());
                            link.AddCssClass(i == PageInfo.CurrPage ? pageClassSelected : pageClassNormal);

                            outputTag.InnerHtml.AppendHtml(link);
                        }
                    }
                    else
                    {
                        for (int i = PageInfo.CurrPage - 1; i <= PageInfo.Pages; i++)
                        {
                            TagBuilder link = new TagBuilder("a");

                            KeyValuePairs["pageNum"] = i;

                            link.Attributes["href"] = UrlHelp.Action("Index", KeyValuePairs);
                            link.InnerHtml.AppendHtml(i.ToString());
                            link.AddCssClass(i == PageInfo.CurrPage ? pageClassSelected : pageClassNormal);

                            outputTag.InnerHtml.AppendHtml(link);
                        }
                    }

                    outputTag.InnerHtml.AppendHtml(nextItem);
                }

                output.Content.AppendHtml(outputTag.InnerHtml);
            }
            else
            {
                for (int i = 1; i <= PageInfo.Pages; i++)
                {
                    TagBuilder link = new TagBuilder("a");

                    KeyValuePairs["pageNum"] = i;

                    link.Attributes["href"] = UrlHelp.Action("Index", KeyValuePairs);
                    link.InnerHtml.AppendHtml(i.ToString());
                    link.AddCssClass(i == PageInfo.CurrPage ? pageClassSelected : pageClassNormal);

                    outputTag.InnerHtml.AppendHtml(link);
                }

                output.Content.AppendHtml(outputTag.InnerHtml);
            }
        }
    }
}