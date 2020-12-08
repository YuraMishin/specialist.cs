using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MVC.Models;

namespace MVC.TagHelpers
{
  /// <summary>
  /// Class PageLinkTagHelper.
  /// Implements taghelper to add pagination
  /// </summary>
  [HtmlTargetElement("div", Attributes = "page-model")]
  public class PageLinkTagHelper : TagHelper
  {
    /// <summary>
    /// IUrlHelperFactory
    /// </summary>
    private IUrlHelperFactory urlHelperFactory;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="helperFactory">IUrlHelperFactory</param>
    public PageLinkTagHelper(IUrlHelperFactory helperFactory)
    {
      urlHelperFactory = helperFactory;
    }

    /// <summary>
    /// ViewContext
    /// </summary>
    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext ViewContext { get; set; }

    /// <summary>
    /// PagingInfo
    /// </summary>
    public PagingInfo PageModel { get; set; }

    /// <summary>
    /// PageAction
    /// </summary>
    public string PageAction { get; set; }

    /// <summary>
    /// PageClassesEnabled
    /// </summary>
    public bool PageClassesEnabled { get; set; }

    /// <summary>
    /// PageClass
    /// </summary>
    public string PageClass { get; set; }

    /// <summary>
    /// PageClassNormal
    /// </summary>
    public string PageClassNormal { get; set; }

    /// <summary>
    /// PageClassSelected
    /// </summary>
    public string PageClassSelected { get; set; }

    /// <summary>
    /// Method adds pagination
    /// </summary>
    /// <param name="context">TagHelperContext</param>
    /// <param name="output">TagHelperOutput</param>
    public override void Process(TagHelperContext context,
      TagHelperOutput output)
    {
      IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
      TagBuilder result = new TagBuilder("div");

      for (int i = 1; i <= PageModel.totalPage; i++)
      {
        TagBuilder tag = new TagBuilder("a");
        string url = PageModel.urlParam.Replace(":", i.ToString());
        tag.Attributes["href"] = url;
        if (PageClassesEnabled)
        {
          tag.AddCssClass(PageClass);
          tag.AddCssClass(i == PageModel.CurrentPage
            ? PageClassSelected
            : PageClassNormal);
        }

        tag.InnerHtml.Append(i.ToString());
        result.InnerHtml.AppendHtml(tag);
      }

      output.Content.AppendHtml(result.InnerHtml);
    }
  }
}
