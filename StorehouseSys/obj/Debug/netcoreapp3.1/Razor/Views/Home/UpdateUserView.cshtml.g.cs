#pragma checksum "C:\Users\777\Desktop\.NetCore6Text\StorehouseSys\StorehouseSys\Views\Home\UpdateUserView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd4121b0af17e95614aae369fe8ce59efca511b2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_UpdateUserView), @"mvc.1.0.view", @"/Views/Home/UpdateUserView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd4121b0af17e95614aae369fe8ce59efca511b2", @"/Views/Home/UpdateUserView.cshtml")]
    #nullable restore
    public class Views_Home_UpdateUserView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/layuimini/lib/layui-v2.6.3/css/layui.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("media", new global::Microsoft.AspNetCore.Html.HtmlString("all"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/layuimini/css/public.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/layuimini/lib/layui-v2.6.3/layui.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("charset", new global::Microsoft.AspNetCore.Html.HtmlString("utf-8"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd4121b0af17e95614aae369fe8ce59efca511b25122", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <title>layui</title>
    <meta name=""renderer"" content=""webkit"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, maximum-scale=1"">
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "cd4121b0af17e95614aae369fe8ce59efca511b25655", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "cd4121b0af17e95614aae369fe8ce59efca511b26921", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <style>\r\n        body {\r\n            background-color: #ffffff;\r\n        }\r\n    </style>\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd4121b0af17e95614aae369fe8ce59efca511b28995", async() => {
                WriteLiteral(@"
<div class=""layui-form layuimini-form""  lay-filter=""formTest"" >

    <div class=""layui-form-item"" style=""display: none;"">
            <label class=""layui-form-label required"">Id</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""Id""");
                BeginWriteAttribute("value", " value=\"", 847, "\"", 855, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
            </div>
        </div>
    <div class=""layui-form-item"">
        <label class=""layui-form-label required"">账号</label>
        <div class=""layui-input-block""> 
            <input type=""text"" name=""Account"" lay-verify=""required"" lay-reqtext=""用户名不能为空"" placeholder=""请输入账号""");
                BeginWriteAttribute("value", " value=\"", 1162, "\"", 1170, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
            <tip>填写自己管理账号。</tip>
        </div>
        <label class=""layui-form-label required"">用户名</label>
        <div class=""layui-input-block""> 
            <input type=""text"" name=""UserName"" lay-verify=""required"" lay-reqtext=""用户名不能为空"" placeholder=""请输入用户名""");
                BeginWriteAttribute("value", " value=\"", 1459, "\"", 1467, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
            <tip>填写自己管理账号的名称。</tip>
        </div>
    </div>
    <div class=""layui-form-item"">
        <label class=""layui-form-label required"">性别</label>
        <div class=""layui-input-block"">
            <input type=""radio"" name=""Sex"" value=""男"" title=""男"">
            <input type=""radio"" name=""Sex"" value=""女"" title=""女"">
        </div>
    </div>
    <div class=""layui-form-item"">
        <label class=""layui-form-label required"">手机</label>
        <div class=""layui-input-block"">
            <input type=""number"" name=""PhoneNum"" lay-verify=""required"" lay-reqtext=""手机不能为空"" placeholder=""请输入手机""");
                BeginWriteAttribute("value", " value=\"", 2099, "\"", 2107, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"layui-input\">\r\n        </div>\r\n    </div>\r\n    <div class=\"layui-form-item\">\r\n        <label class=\"layui-form-label\">邮箱</label>\r\n        <div class=\"layui-input-block\">\r\n            <input type=\"email\" name=\"Email\" placeholder=\"请输入邮箱\"");
                BeginWriteAttribute("value", " value=\"", 2351, "\"", 2359, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"layui-input\">\r\n        </div>\r\n    </div>\r\n    <div class=\"layui-form-item\">\r\n        <label class=\"layui-form-label\">部门</label>\r\n        <div class=\"layui-input-block\">\r\n            <input type=\"text\" name=\"DepartmentId\" placeholder=\"请输入职业\"");
                BeginWriteAttribute("value", " value=\"", 2609, "\"", 2617, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"layui-input\">\r\n        </div>\r\n    </div>\r\n");
                WriteLiteral(">\r\n\r\n    <div class=\"layui-form-item\">\r\n        <div class=\"layui-input-block\">\r\n            <button class=\"layui-btn layui-btn-normal\" lay-submit lay-filter=\"saveBtn\">确认保存</button>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd4121b0af17e95614aae369fe8ce59efca511b212652", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
<script>
    layui.use(['form'], function () {
        
         var form = layui.form,
                layer = layui.layer,
                $ = layui.$;
            var table = layui.table;


        var id = window.location.search.substr(4);
         console.log(parent.layer.getFrameIndex(window.name));
          //发起异步请求
            $.ajax({
                url: '/Home/GetUserInfoById',
                type: 'get',
                data: {
                    id: id
                },
                success: function (res) {
                    if (res.data != null) {
                        //给表单赋值
                        form.val(""formTest"", { //formTest 即 class=""layui-form"" 所在元素属性 lay-filter="""" 对应的值
                            ""Id"": res.data.id
                            , ""Account"": res.data.account
                            , ""PassWord"": res.data.passWord
                            , ""UserName"": res.data.userName
                            , ""PhoneNum"": res.data.phoneN");
                WriteLiteral(@"um
                            , ""Email"": res.data.email
                            , ""DepartmentId"": res.data.departmentId
                            , ""Sex"": res.data.sex
                        });

                    } else { 
                    
                        layer.msg(res.msg)
                    }
                   
                  
                }
            });
         
        //监听提交
        form.on('submit(saveBtn)', function (data) {
``              

            $.ajax({
                    
                url:""/home/UpdateUserInfo"",
                type:""post"",
                data: data.field,
                success : function (res)
                { 
                    if (res.ses) {
                            //关闭当前编辑页
                            var iframeIndex = parent.layer.getFrameIndex(window.name);
                            parent.layer.close(iframeIndex);
                            //刷新列表
                            parent.tabl");
                WriteLiteral(@"e.reload('testReload', {
                                page: {
                                    curr: 1
                                }
                                , where: {
                                }
                            }, 'data');

                        } else {
                            layer.msg(res.msg);
                        }



                }
            
            })

        });

    });
</script>
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
