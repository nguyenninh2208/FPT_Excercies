#pragma checksum "D:\FPT_Work\Excercies\QuanLyHocSinh\QuanLyHocSinh.App\Views\Subjects\IndexSubjects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4870dd94151c6bb09509fa4b960d0dbd8d4f1cd5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Subjects_IndexSubjects), @"mvc.1.0.view", @"/Views/Subjects/IndexSubjects.cshtml")]
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
#line 1 "D:\FPT_Work\Excercies\QuanLyHocSinh\QuanLyHocSinh.App\Views\_ViewImports.cshtml"
using QuanLyHocSinh.App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\FPT_Work\Excercies\QuanLyHocSinh\QuanLyHocSinh.App\Views\_ViewImports.cshtml"
using QuanLyHocSinh.App.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4870dd94151c6bb09509fa4b960d0dbd8d4f1cd5", @"/Views/Subjects/IndexSubjects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"851d6d3da08e9026f670d68e993ebdca2401e690", @"/Views/_ViewImports.cshtml")]
    public class Views_Subjects_IndexSubjects : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<QuanLyHocSinh.Models.SubjectsModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_GetListSubjects", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\FPT_Work\Excercies\QuanLyHocSinh\QuanLyHocSinh.App\Views\Subjects\IndexSubjects.cshtml"
  
    ViewData["Title"] = "Môn học";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""float-right"">
                <button class=""btn btn-primary"" id=""btnAddSub"">Thêm môn học</button>
            </div>
        </div>
    </div>
    <hr />
    <div class=""row"">
        <div class=""col-md-12"">
            <h2>Danh sách học sinh</h2>
            <div id=""dsSubj"">
");
#nullable restore
#line 20 "D:\FPT_Work\Excercies\QuanLyHocSinh\QuanLyHocSinh.App\Views\Subjects\IndexSubjects.cshtml"
                 if (Model != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4870dd94151c6bb09509fa4b960d0dbd8d4f1cd54416", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 22 "D:\FPT_Work\Excercies\QuanLyHocSinh\QuanLyHocSinh.App\Views\Subjects\IndexSubjects.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 23 "D:\FPT_Work\Excercies\QuanLyHocSinh\QuanLyHocSinh.App\Views\Subjects\IndexSubjects.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>

        $('#btnAddSub').click(function () {
            ShowPopupCustomize('/subjects/_InsertSubjects', ""Thêm môn học"", 700, 1, """", """");
        })

        var onSuccess = function (e) {
            $.ajax({
                url: '/subjects/_GetListSubjects',
                type: 'GET',
                success: function (rs) {
                    $('#dsSubj').html(rs);
                }
            });
        }
        var onComplete = function () {
            $('#modal-notify').modal('hide');
        }
        var onError = function (err) {
            alert(""Thất bại"")
        }

        var updateSub = function (id) {
            ShowPopupCustomize('/subjects/_UpdateSubjects?id='+id, ""Sửa môn học"", 700, 1, """", """");
        }

        var deleteSub = function (id) {
            var conf = confirm('Xóa ?');
            if (conf) {
                $.ajax({
                    url: '/subjects/DelSubjects',
                    type: 'POST',
                    ");
                WriteLiteral("data: { id: id },\r\n                    success: function () {\r\n                        onSuccess(null);\r\n                    }\r\n                });\r\n            }\r\n        }\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<QuanLyHocSinh.Models.SubjectsModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
