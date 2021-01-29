#pragma checksum "D:\My Project\.NetCoreLibraryManagement\Library\Library\Views\Branch\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75b1bd2754aa84ba9b7bcaf1a732e857623a1505"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Branch_Detail), @"mvc.1.0.view", @"/Views/Branch/Detail.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\My Project\.NetCoreLibraryManagement\Library\Library\Views\_ViewImports.cshtml"
using Library;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\My Project\.NetCoreLibraryManagement\Library\Library\Views\_ViewImports.cshtml"
using Library.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75b1bd2754aa84ba9b7bcaf1a732e857623a1505", @"/Views/Branch/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dadb7a731bfbb305c411bc5eb7a307dbd6008a89", @"/Views/_ViewImports.cshtml")]
    public class Views_Branch_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Library.Web.ViewModels.BranchViewModels.BranchDetailViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\My Project\.NetCoreLibraryManagement\Library\Library\Views\Branch\Detail.cshtml"
   
    ViewBag.Title = $"{Model.Name} Branch";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"card-header clearfix detailHeading\">\r\n        <h2 class=\"text-muted\">Branch Information</h2>\r\n    </div>\r\n    <div class=\"jumbotron\">\r\n        <div class=\"row\">\r\n            <img");
            BeginWriteAttribute("src", "  src=\"", 344, "\"", 366, 1);
#nullable restore
#line 12 "D:\My Project\.NetCoreLibraryManagement\Library\Library\Views\Branch\Detail.cshtml"
WriteAttributeValue("", 351, Model.ImageUrl, 351, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\r\n        </div>\r\n        <div class=\"row branchInfo\">\r\n            <h2>");
#nullable restore
#line 15 "D:\My Project\.NetCoreLibraryManagement\Library\Library\Views\Branch\Detail.cshtml"
           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n            <div class=\"col-md-8\">\r\n                <div class=\"branchContact\">\r\n                    <div id=\"branchAddress\">Address: ");
#nullable restore
#line 18 "D:\My Project\.NetCoreLibraryManagement\Library\Library\Views\Branch\Detail.cshtml"
                                                Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n                    <div id=\"branchTel\">Telephone: ");
#nullable restore
#line 19 "D:\My Project\.NetCoreLibraryManagement\Library\Library\Views\Branch\Detail.cshtml"
                                              Write(Model.Telephone);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n\r\n                </div>\r\n                <div id=\"branchDescription\">\r\n                    <p class=\"caption\">");
#nullable restore
#line 23 "D:\My Project\.NetCoreLibraryManagement\Library\Library\Views\Branch\Detail.cshtml"
                                  Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n                <div class=\"branchHours\">\r\n                    <ul>\r\n");
#nullable restore
#line 27 "D:\My Project\.NetCoreLibraryManagement\Library\Library\Views\Branch\Detail.cshtml"
                         foreach (var day in Model.HoursOpen)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li>");
#nullable restore
#line 29 "D:\My Project\.NetCoreLibraryManagement\Library\Library\Views\Branch\Detail.cshtml"
                           Write(day);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 30 "D:\My Project\.NetCoreLibraryManagement\Library\Library\Views\Branch\Detail.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </ul>
                </div>
            </div>
            <div class=""col-md-4"">
                <table>
                    <tr>
                        <td class=""itemLabel"">Date Opened: </td>
                        <td class=""itemValue"">");
#nullable restore
#line 38 "D:\My Project\.NetCoreLibraryManagement\Library\Library\Views\Branch\Detail.cshtml"
                                         Write(Model.OpenDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                    </tr>
                    <tr>
                        <td class=""itemLabel"">
                            Number Of Patrons:
                        </td>
                        <td class=""itemValue"">
                            ");
#nullable restore
#line 45 "D:\My Project\.NetCoreLibraryManagement\Library\Library\Views\Branch\Detail.cshtml"
                       Write(Model.NumberOfPatrons);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td class=\"itemLabel\">Number Of Assets: </td>\r\n                        <td class=\"itemValue\">");
#nullable restore
#line 50 "D:\My Project\.NetCoreLibraryManagement\Library\Library\Views\Branch\Detail.cshtml"
                                         Write(Model.NumberOfAssets);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td class=\"itemLabel\">Value Of Assets: </td>\r\n                        <td class=\"itemValue\">$");
#nullable restore
#line 54 "D:\My Project\.NetCoreLibraryManagement\Library\Library\Views\Branch\Detail.cshtml"
                                          Write(Model.TotalAssetValue);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Library.Web.ViewModels.BranchViewModels.BranchDetailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591