#pragma checksum "C:\Users\777\Desktop\.NetCore6Text\StorehouseSys\StorehouseSys\Views\ConsumableInfo\AddConsumableInfoView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86f8d831c536861c3f5719af19f9b6eaa3e12508"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ConsumableInfo_AddConsumableInfoView), @"mvc.1.0.view", @"/Views/ConsumableInfo/AddConsumableInfoView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86f8d831c536861c3f5719af19f9b6eaa3e12508", @"/Views/ConsumableInfo/AddConsumableInfoView.cshtml")]
    #nullable restore
    public class Views_ConsumableInfo_AddConsumableInfoView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\777\Desktop\.NetCore6Text\StorehouseSys\StorehouseSys\Views\ConsumableInfo\AddConsumableInfoView.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86f8d831c536861c3f5719af19f9b6eaa3e125083107", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <title>layui</title>
    <meta name=""renderer"" content=""webkit"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, maximum-scale=1"">
    <link rel=""stylesheet"" href=""../layuimini/lib/layui-v2.6.3/css/layui.css"" media=""all"">
    <link rel=""stylesheet"" href=""../layuimini/css/public.css"" media=""all"">
    <style>
        body {
            background-color: #ffffff;
        }
    </style>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86f8d831c536861c3f5719af19f9b6eaa3e125084618", async() => {
                WriteLiteral(@"
    <div class=""layui-form layuimini-form"">
        <div class=""layui-form-item"">
            <label class=""layui-form-label required"">????????????</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""consumableName"" lay-verify=""required"" lay-reqtext=""????????????????????????"" placeholder=""?????????????????????""");
                BeginWriteAttribute("value", " value=\"", 916, "\"", 924, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
            </div>
        </div>

        <div class=""layui-form-item"">
            <label class=""layui-form-label"">????????????</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""specification"" placeholder=""?????????????????????""");
                BeginWriteAttribute("value", " value=\"", 1205, "\"", 1213, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
            </div>
        </div>
        <div class=""layui-form-item"">
            <label class=""layui-form-label"">??????</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""unit"" placeholder=""???????????????""");
                BeginWriteAttribute("value", " value=\"", 1479, "\"", 1487, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
            </div>
        </div>
        <div class=""layui-form-item"">
            <label class=""layui-form-label"">??????</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""money"" placeholder=""???????????????""");
                BeginWriteAttribute("value", " value=\"", 1754, "\"", 1762, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
            </div>
        </div>
        <div class=""layui-form-item"">
            <label class=""layui-form-label"">????????????</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""warningNum"" placeholder=""?????????????????????""");
                BeginWriteAttribute("value", " value=\"", 2038, "\"", 2046, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
            </div>
        </div>
        <div class=""layui-form-item"">
            <label class=""layui-form-label"">??????</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""description"" placeholder=""???????????????""");
                BeginWriteAttribute("value", " value=\"", 2319, "\"", 2327, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"layui-input\">\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"layui-form-item\">\r\n            <label class=\"layui-form-label\">????????????</label>\r\n            <div class=\"layui-input-block\">\r\n");
                WriteLiteral("                <select name=\"CategoryId\" id=\"categorySelect\">\r\n                    <option");
                BeginWriteAttribute("value", " value=\"", 2734, "\"", 2742, 0);
                EndWriteAttribute();
                WriteLiteral(@"></option>
                </select>
            </div>
        </div>

        <div class=""layui-form-item"">
            <div class=""layui-input-block"">
                <button class=""layui-btn layui-btn-normal"" lay-submit lay-filter=""saveBtn"">????????????</button>
            </div>
        </div>
    </div>
    <script src=""../layuimini/lib/layui-v2.6.3/layui.js"" charset=""utf-8""></script>
    <script>
        layui.use(['form'], function () {
            var form = layui.form,
                layer = layui.layer,
                $ = layui.$;

            //?????????????????????
            $.ajax({
                url: '/ConsumableInfo/GetCategoryOptions',
                type: 'get',
                success: function (res) {
                    if (res.ses) {
                    
                            for (var i = 0; i < res.data.length; i++) {
                                $('#categorySelect').append('<option value=""' + res.data[i].id + '"">' + res.data[i].categoryName + '</option>');
       ");
                WriteLiteral(@"                     }
                            form.render('select'); //??????select???????????????
                        
                    }
                }
            });


            //????????????
            form.on('submit(saveBtn)', function (data) {

                console.log(data);

                //??????????????????
                $.ajax({
                    url: '/ConsumableInfo/AddConsumableInfo',
                    type: 'post',

                    data: data.field,
                    success: function (res) {
                        if (res.ses) {
                            //????????????
                            parent.table.reload('currentTableId', {
                                page: {
                                    curr: 1
                                }
                                , where: {
                                }
                            }, 'data');

                            //???????????????
                            var iframeIndex = parent.layer.get");
                WriteLiteral(@"FrameIndex(window.name);
                            parent.layer.close(iframeIndex);
                        } else {
                            layer.msg(res.msg);
                        }
                    }
                });


                return false;
            });

        });</script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
