﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HangFire.Web.Pages
{
    
    #line 2 "..\..\Pages\JobDetailsPage.cshtml"
    using System;
    
    #line default
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    #line 3 "..\..\Pages\JobDetailsPage.cshtml"
    using Pages;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class JobDetailsPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");





            
            #line 5 "..\..\Pages\JobDetailsPage.cshtml"
  
    Layout = new LayoutPage { Title = "Job Details" };
    var job = JobStorage.JobDetails(JobId.ToString());


            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 10 "..\..\Pages\JobDetailsPage.cshtml"
 if (job == null)
{

            
            #line default
            #line hidden
WriteLiteral("    ");

WriteLiteral(" The job with id \'");


            
            #line 12 "..\..\Pages\JobDetailsPage.cshtml"
                   Write(JobId);

            
            #line default
            #line hidden
WriteLiteral("\' was expired or was not existed on the server.\r\n");


            
            #line 13 "..\..\Pages\JobDetailsPage.cshtml"
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <dl class=\"dl-horizontal\">\r\n        <dt>Id</dt>\r\n        <dd>");


            
            #line 18 "..\..\Pages\JobDetailsPage.cshtml"
       Write(JobId);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n    \r\n        <dt>Type</dt>\r\n        <dd>");


            
            #line 21 "..\..\Pages\JobDetailsPage.cshtml"
       Write(HtmlHelper.JobType(job.Type));

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n    \r\n        <dt>Arguments</dt>\r\n        <dd><code>");


            
            #line 24 "..\..\Pages\JobDetailsPage.cshtml"
             Write(HtmlHelper.FormatProperties(job.Arguments));

            
            #line default
            #line hidden
WriteLiteral("</code></dd>\r\n    \r\n");


            
            #line 26 "..\..\Pages\JobDetailsPage.cshtml"
         foreach (var property in job.Properties)
        {

            
            #line default
            #line hidden
WriteLiteral("            <dt>");


            
            #line 28 "..\..\Pages\JobDetailsPage.cshtml"
           Write(property.Key);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n");



WriteLiteral("            <dd>");


            
            #line 29 "..\..\Pages\JobDetailsPage.cshtml"
           Write(property.Value);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n");


            
            #line 30 "..\..\Pages\JobDetailsPage.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </dl>\r\n");


            
            #line 32 "..\..\Pages\JobDetailsPage.cshtml"
}
            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
