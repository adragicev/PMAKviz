#pragma checksum "C:\Users\AnnieD\Desktop\KvizAD – 30-08-Final1\KvizAD – 30-08-Final1\KvizAD – 30-08-Final\KvizAD – kopija-30.8\Views\TheEnd\Win.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "04c07109769504307c5d322c0fbeccc549a3fb94"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TheEnd_Win), @"mvc.1.0.view", @"/Views/TheEnd/Win.cshtml")]
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
#line 1 "C:\Users\AnnieD\Desktop\KvizAD – 30-08-Final1\KvizAD – 30-08-Final1\KvizAD – 30-08-Final\KvizAD – kopija-30.8\Views\_ViewImports.cshtml"
using KvizAD;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\AnnieD\Desktop\KvizAD – 30-08-Final1\KvizAD – 30-08-Final1\KvizAD – 30-08-Final\KvizAD – kopija-30.8\Views\_ViewImports.cshtml"
using KvizAD.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04c07109769504307c5d322c0fbeccc549a3fb94", @"/Views/TheEnd/Win.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f48f0c99b7b000ad6595372092618a36909ca4de", @"/Views/_ViewImports.cshtml")]
    public class Views_TheEnd_Win : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\AnnieD\Desktop\KvizAD – 30-08-Final1\KvizAD – 30-08-Final1\KvizAD – 30-08-Final\KvizAD – kopija-30.8\Views\TheEnd\Win.cshtml"
  
    ViewData["Title"] = "Win";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <link href=""https://fonts.googleapis.com/icon?family=Material+Icons"" rel=""stylesheet"">
<style>
    #div1 {
        font-size: 24px;
        font-weight: 400;
        font-weight:bold;
        height: 330px;
    }
   .happy {
        padding-top: 15%;
        width: 95%;
        height: 98%;
    }
    .material-icons {
        font-size: 36px;   
      
    }
    #transbox {
        margin-top: 20%;
        padding: 8px;
        padding-top: 20px;
        margin-bottom: 5px;
        background-color: #ffffff;
        border: 1px solid black;
        opacity: 0.7;
        height: 10%;
        width: 250px;
    }
   
     
    
</style>



<div id=""div1"" class=""site-section-cover overlay"" style=""background-image: url('../images/Background-image.jpg');"">

    <div class=""container"">
        <div class=""row align-items-center justify-content-center"">
            <!-- <label id=""score"">Rezultat: 0</label>-->
            <div class=""row"">
                <div id=""transbox");
            WriteLiteral(@""" class=""col-md-7 text-center"">
                    <p>
                        Čestitke !
                        Kviz ste riješili sa uspješnošću.
                        <br />
                        Želite li odigrati ponovo?
                    </p>
                    <button id=""replay"" class=""btn btn-link"" onclick=""window.location.href = '../User/Index';""> <i class=""material-icons md-light"">replay</i></button>
                </div>
                <div class=""col-md-5 text-center""><img src=""../images/Happyemoji.jpg"" class=""happy""></div>
            </div>
           <!-- <img src=""../images/Happyemoji.jpg"" class=""happy""><br />
            <div class=""col-lg-10 text-center"">
                <p>
                    Čestitke !
                    Kviz ste riješili sa uspješnošću.
                    <br />
                    Želite li odigrati ponovo?
                </p>
                <button id=""replay"" class=""btn btn-link"" onclick=""window.location.href = '../User/Index';""> <i c");
            WriteLiteral("lass=\"material-icons md-light\">replay</i></button>\r\n\r\n                <!-- <div class=\"center\">\r\n        <button onclick=\"Odgovori()\" class=\"btn\">Next</button></div></div>-->\r\n            \r\n\r\n        \r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
