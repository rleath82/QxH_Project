#pragma checksum "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ae0c1abbbba21b10b46a21f04f5084e82c8f0236"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_USAs_Delete), @"mvc.1.0.view", @"/Views/USAs/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/USAs/Delete.cshtml", typeof(AspNetCore.Views_USAs_Delete))]
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
#line 1 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\_ViewImports.cshtml"
using QxHOrderSystem;

#line default
#line hidden
#line 2 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\_ViewImports.cshtml"
using QxHOrderSystem.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae0c1abbbba21b10b46a21f04f5084e82c8f0236", @"/Views/USAs/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f194ceba60979f123bc3e98d1b3cd468415ea27", @"/Views/_ViewImports.cshtml")]
    public class Views_USAs_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QxHOrderSystem.Models.USA>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(34, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(78, 173, true);
            WriteLiteral("\r\n<h1>Delete</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>USA</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(252, 45, false);
#line 15 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.planSeqId));

#line default
#line hidden
            EndContext();
            BeginContext(297, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(361, 41, false);
#line 18 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.planSeqId));

#line default
#line hidden
            EndContext();
            BeginContext(402, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(465, 51, false);
#line 21 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.itemDescription));

#line default
#line hidden
            EndContext();
            BeginContext(516, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(580, 47, false);
#line 24 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.itemDescription));

#line default
#line hidden
            EndContext();
            BeginContext(627, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(690, 49, false);
#line 27 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.orderQuantity));

#line default
#line hidden
            EndContext();
            BeginContext(739, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(803, 45, false);
#line 30 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.orderQuantity));

#line default
#line hidden
            EndContext();
            BeginContext(848, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(911, 47, false);
#line 33 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.orderSldTdy));

#line default
#line hidden
            EndContext();
            BeginContext(958, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1022, 43, false);
#line 36 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.orderSldTdy));

#line default
#line hidden
            EndContext();
            BeginContext(1065, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1128, 53, false);
#line 39 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.plannedMinutesQty));

#line default
#line hidden
            EndContext();
            BeginContext(1181, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1245, 49, false);
#line 42 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.plannedMinutesQty));

#line default
#line hidden
            EndContext();
            BeginContext(1294, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1357, 52, false);
#line 45 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.actualMinutesQty));

#line default
#line hidden
            EndContext();
            BeginContext(1409, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1473, 48, false);
#line 48 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.actualMinutesQty));

#line default
#line hidden
            EndContext();
            BeginContext(1521, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1584, 45, false);
#line 51 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.networkId));

#line default
#line hidden
            EndContext();
            BeginContext(1629, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1693, 41, false);
#line 54 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.networkId));

#line default
#line hidden
            EndContext();
            BeginContext(1734, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1797, 45, false);
#line 57 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.companyId));

#line default
#line hidden
            EndContext();
            BeginContext(1842, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1906, 41, false);
#line 60 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.companyId));

#line default
#line hidden
            EndContext();
            BeginContext(1947, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2010, 50, false);
#line 63 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.avaiForSaleQty));

#line default
#line hidden
            EndContext();
            BeginContext(2060, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2124, 46, false);
#line 66 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.avaiForSaleQty));

#line default
#line hidden
            EndContext();
            BeginContext(2170, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2233, 44, false);
#line 69 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.showDate));

#line default
#line hidden
            EndContext();
            BeginContext(2277, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2341, 40, false);
#line 72 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.showDate));

#line default
#line hidden
            EndContext();
            BeginContext(2381, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2444, 42, false);
#line 75 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.showCd));

#line default
#line hidden
            EndContext();
            BeginContext(2486, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2550, 38, false);
#line 78 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.showCd));

#line default
#line hidden
            EndContext();
            BeginContext(2588, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(2626, 214, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ae0c1abbbba21b10b46a21f04f5084e82c8f023615466", async() => {
                BeginContext(2652, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(2662, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ae0c1abbbba21b10b46a21f04f5084e82c8f023615859", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 83 "C:\Users\Robert Leatherman\Desktop\HSN Internship\QxH FINAL PROJECT\QxHOrderSystem\QxHOrderSystem\Views\USAs\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ShowItemId);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2706, 83, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n        ");
                EndContext();
                BeginContext(2789, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ae0c1abbbba21b10b46a21f04f5084e82c8f023617816", async() => {
                    BeginContext(2811, 12, true);
                    WriteLiteral("Back to List");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2827, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2840, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QxHOrderSystem.Models.USA> Html { get; private set; }
    }
}
#pragma warning restore 1591