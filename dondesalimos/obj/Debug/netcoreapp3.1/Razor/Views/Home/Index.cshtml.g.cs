#pragma checksum "E:\dondesalimos\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f390e0c41c2d3d0ef2990e8e62ee7a6f19f13570"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "E:\dondesalimos\Views\_ViewImports.cshtml"
using dondesalimos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\dondesalimos\Views\_ViewImports.cshtml"
using dondesalimos.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f390e0c41c2d3d0ef2990e8e62ee7a6f19f13570", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c2189eee1af3a9ad4f1b2b72f613bbd45e4b8f9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/carrousel1.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-flex"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\dondesalimos\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<main>

    <div id=""myCarousel"" class=""carousel slide fixed"" data-bs-ride=""carousel"">
        <div class=""carousel-indicators"">
            <button type=""button"" data-bs-target=""#myCarousel"" data-bs-slide-to=""0"" class=""active"" aria-current=""true"" aria-label=""Slide 1""></button>

        </div>
        <div class=""carousel-inner"">
            <div class=""carousel-item active"">
                
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f390e0c41c2d3d0ef2990e8e62ee7a6f19f135705251", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <div class=""container"">
                    <div class=""carousel-caption text-start"">
                        <h1>Abri tu mente</h1>
                        <p>Conoce nuevos lugares </p>
                        <p>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f390e0c41c2d3d0ef2990e8e62ee7a6f19f135706632", async() => {
                WriteLiteral("\r\n                                <input class=\"form-control me-2\" type=\"search\" placeholder=\"Buscar\" aria-label=\"Search\">\r\n                                <button class=\"btn btn01\" type=\"submit\">Buscar</button>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </p>
                    </div>
                </div>
            </div>

        </div>
    </div>

    



    <hr class=""featurette-divider"">

    <div class=""row featurette"">
        <div class=""col-md-7"">
            <h2 class=""featurette-heading"">First featurette heading. <span class=""text-muted"">It’ll blow your mind.</span></h2>
            <p class=""lead"">Some great placeholder content for the first featurette here. Imagine some exciting prose here.</p>
        </div>
        <div class=""col-md-5"">
            <svg class=""bd-placeholder-img bd-placeholder-img-lg featurette-image img-fluid mx-auto"" width=""500"" height=""500"" xmlns=""http://www.w3.org/2000/svg"" role=""img"" aria-label=""Placeholder: 500x500"" preserveAspectRatio=""xMidYMid slice"" focusable=""false""><title>Placeholder</title><rect width=""100%"" height=""100%"" fill=""#eee"" /><text x=""50%"" y=""50%"" fill=""#aaa"" dy="".3em"">500x500</text></svg>

        </div>
    </div>

    <hr class=""featurette-divider");
            WriteLiteral(@""">

    <div class=""row featurette"">
        <div class=""col-md-7 order-md-2"">
            <h2 class=""featurette-heading"">Oh yeah, it’s that good. <span class=""text-muted"">See for yourself.</span></h2>
            <p class=""lead"">Another featurette? Of course. More placeholder content here to give you an idea of how this layout would work with some actual real-world content in place.</p>
        </div>
        <div class=""col-md-5 order-md-1"">
            <svg class=""bd-placeholder-img bd-placeholder-img-lg featurette-image img-fluid mx-auto"" width=""500"" height=""500"" xmlns=""http://www.w3.org/2000/svg"" role=""img"" aria-label=""Placeholder: 500x500"" preserveAspectRatio=""xMidYMid slice"" focusable=""false""><title>Placeholder</title><rect width=""100%"" height=""100%"" fill=""#eee"" /><text x=""50%"" y=""50%"" fill=""#aaa"" dy="".3em"">500x500</text></svg>

        </div>
    </div>

    <hr class=""featurette-divider"">

    <div class=""row featurette"">
        <div class=""col-md-7"">
            <h2 class=""featuret");
            WriteLiteral(@"te-heading"">And lastly, this one. <span class=""text-muted"">Checkmate.</span></h2>
            <p class=""lead"">And yes, this is the last block of representative placeholder content. Again, not really intended to be actually read, simply here to give you a better view of what this would look like with some actual content. Your content.</p>
        </div>
        <div class=""col-md-5"">
            <svg class=""bd-placeholder-img bd-placeholder-img-lg featurette-image img-fluid mx-auto"" width=""500"" height=""500"" xmlns=""http://www.w3.org/2000/svg"" role=""img"" aria-label=""Placeholder: 500x500"" preserveAspectRatio=""xMidYMid slice"" focusable=""false""><title>Placeholder</title><rect width=""100%"" height=""100%"" fill=""#eee"" /><text x=""50%"" y=""50%"" fill=""#aaa"" dy="".3em"">500x500</text></svg>

        </div>
    </div>

    <hr class=""featurette-divider"">





</main>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591