#pragma checksum "C:\Users\777\Desktop\.NetCore6Text\StorehouseSys\StorehouseSys\Views\ConsumableInfo\UpdateConsumableInfoView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d17f66b8e827c70f7056836f53796490f2d374c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ConsumableInfo_UpdateConsumableInfoView), @"mvc.1.0.view", @"/Views/ConsumableInfo/UpdateConsumableInfoView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d17f66b8e827c70f7056836f53796490f2d374c", @"/Views/ConsumableInfo/UpdateConsumableInfoView.cshtml")]
    #nullable restore
    public class Views_ConsumableInfo_UpdateConsumableInfoView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "C:\Users\777\Desktop\.NetCore6Text\StorehouseSys\StorehouseSys\Views\ConsumableInfo\UpdateConsumableInfoView.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d17f66b8e827c70f7056836f53796490f2d374c3125", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d17f66b8e827c70f7056836f53796490f2d374c4636", async() => {
                WriteLiteral(@"
    <div class=""layui-form layuimini-form"" lay-filter=""formTest"">
        <div class=""layui-form-item"" style=""display: none;"">
            <label class=""layui-form-label required"">Id</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""id""");
                BeginWriteAttribute("value", " value=\"", 880, "\"", 888, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
            </div>
        </div>
        <div class=""layui-form-item"">
            <label class=""layui-form-label required"">耗材名称</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""consumableName"" lay-verify=""required"" lay-reqtext=""耗材名称不能为空"" placeholder=""请输入耗材名称""");
                BeginWriteAttribute("value", " value=\"", 1222, "\"", 1230, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
            </div>
        </div>

        <div class=""layui-form-item"">
            <label class=""layui-form-label"">耗材规格</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""specification"" placeholder=""请输入耗材规格""");
                BeginWriteAttribute("value", " value=\"", 1511, "\"", 1519, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
            </div>
        </div>
        <div class=""layui-form-item"">
            <label class=""layui-form-label"">单位</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""unit"" placeholder=""请输入单位""");
                BeginWriteAttribute("value", " value=\"", 1785, "\"", 1793, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
            </div>
        </div>
        <div class=""layui-form-item"">
            <label class=""layui-form-label"">价格</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""money"" placeholder=""请输入价格""");
                BeginWriteAttribute("value", " value=\"", 2060, "\"", 2068, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
            </div>
        </div>
        <div class=""layui-form-item"">
            <label class=""layui-form-label"">警告库存</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""warningNum"" placeholder=""请输入警告库存""");
                BeginWriteAttribute("value", " value=\"", 2344, "\"", 2352, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
            </div>
        </div>
        <div class=""layui-form-item"">
            <label class=""layui-form-label"">描述</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""description"" placeholder=""请输入描述""");
                BeginWriteAttribute("value", " value=\"", 2625, "\"", 2633, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"layui-input\">\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"layui-form-item\">\r\n            <label class=\"layui-form-label\">耗材类型</label>\r\n            <div class=\"layui-input-block\">\r\n");
                WriteLiteral("                <select name=\"CategoryId\" id=\"categorySelect\">\r\n                    <option");
                BeginWriteAttribute("value", " value=\"", 3040, "\"", 3048, 0);
                EndWriteAttribute();
                WriteLiteral(@"></option>
                </select>
            </div>
        </div>


        <div class=""layui-form-item"">
            <div class=""layui-input-block"">
                <button class=""layui-btn layui-btn-normal"" lay-submit lay-filter=""saveBtn"">确认保存</button>
            </div>
        </div>
    </div>
    <script src=""../layuimini/lib/layui-v2.6.3/layui.js"" charset=""utf-8""></script>
    <script>        layui.use(['form'], function () {
            var form = layui.form,
                layer = layui.layer,
                $ = layui.$;
            var table = layui.table;

            //通过url获取当前要编辑的耗材id
           var id = window.location.search.substr(4);
            

            //发起异步请求
            $.ajax({
                url: '/ConsumableInfo/GetUpdateConsumableInfo',
                type: 'get',
                data: {
                    id: id
                },
                success: function (res) {
                    //类别的下拉选数据
                    var options =");
                WriteLiteral(@" res.data.options;
                    for (var i = 0; i < options.length; i++) {
                        //获取类别下拉选元素
                        $('#categorySelect').append('<option value=""' + options[i].id + '"">' + options[i].categoryName + '</option>');
                    }

                    //渲染 select 选择框
                    form.render('select');

                    //给表单赋值
                    form.val(""formTest"", { //formTest 即 class=""layui-form"" 所在元素属性 lay-filter="""" 对应的值
                        ""id"": res.data.consumableInfo.id
                        , ""consumableName"": res.data.consumableInfo.consumableName
                        , ""specification"": res.data.consumableInfo.specification
                        , ""consumableName"": res.data.consumableInfo.consumableName
                        , ""unit"": res.data.consumableInfo.unit
                        , ""warningNum"": res.data.consumableInfo.warningNum
                        , ""money"": res.data.consumableInfo.money
              ");
                WriteLiteral(@"          , ""description"": res.data.consumableInfo.description
                       
                    });
                }
            });

            //监听提交
            form.on('submit(saveBtn)', function (data) {

                console.log(data);

                //发起异步请求
                $.ajax({
                    url: '/ConsumableInfo/UpdateConsumableInfo',
                    type: 'post',
                    //data: {
                    //    account: data.field.Account
                    //},
                    data: data.field,
                    success: function (res) {
                        if (res.ses) {
                            //关闭当前编辑页
                            var iframeIndex = parent.layer.getFrameIndex(window.name);
                            parent.layer.close(iframeIndex);

                            //刷新列表
                            parent.table.reload('currentTableId', {
                                page: {
                          ");
                WriteLiteral(@"          curr: 1
                                }
                                , where: {
                                }
                            }, 'data');

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
