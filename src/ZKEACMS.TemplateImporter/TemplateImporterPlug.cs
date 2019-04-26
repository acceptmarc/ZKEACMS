﻿/* http://www.zkea.net/ 
 * Copyright 2017 ZKEASOFT 
 * http://www.zkea.net/licenses 
 *
 */
using Easy.Mvc.Resource;
using Easy.Mvc.Route;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Easy.RepositoryPattern;
using Easy;
using ZKEACMS.WidgetTemplate;
using ZKEACMS.TemplateImporter.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.IO.Compression;

namespace ZKEACMS.TemplateImporter
{
    public class TemplateImporterPlug : PluginBase
    {
        public override IEnumerable<RouteDescriptor> RegistRoute()
        {
            return null;
        }

        public override IEnumerable<AdminMenu> AdminMenu()
        {
            yield return new AdminMenu
            {
                Group = "系统",
                Title = "导入静态模板",
                Icon = "glyphicon-fire",
                PermissionKey = PermissionKeys.ImportStaticHtmlTemplate,
                Url = "~/admin/TemplateImporter",
                Order = 15
            };
        }

        protected override void InitScript(Func<string, ResourceHelper> script)
        {

        }

        protected override void InitStyle(Func<string, ResourceHelper> style)
        {

        }

        public override IEnumerable<PermissionDescriptor> RegistPermission()
        {
            yield return new PermissionDescriptor(PermissionKeys.ImportStaticHtmlTemplate, "设置", "导入静态模板", "");
        }

        public override IEnumerable<WidgetTemplateEntity> WidgetServiceTypes()
        {
            return null;
        }

        public override void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ITemplateImporterService, TemplateImporterService>();
        }
    }
}