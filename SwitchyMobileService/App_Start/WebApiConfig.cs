using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Web.Http;
using SwitchyMobileService.DataObjects;
using SwitchyMobileService.Models;
using Microsoft.WindowsAzure.Mobile.Service;
using AutoMapper;


namespace SwitchyMobileService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            //Database.SetInitializer(new MobileServiceInitializer());

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<MobileCalibrationRecord, CalibrationRecord>();
                cfg.CreateMap<MobileFlowswitch, Flowswitch>();
                cfg.CreateMap<CalibrationRecord, MobileCalibrationRecord>()
                    .ForMember(dst => dst.MobileFlowswitchId, map => map.MapFrom(x => x.Flowswitch.ID))
                    .ForMember(dst => dst.MobileFlowswitchName, map => map.MapFrom(x => x.Flowswitch.Name));
                cfg.CreateMap<Flowswitch, MobileFlowswitch>();

            });
        }
    }

    //public class MobileServiceInitializer : DropCreateDatabaseIfModelChanges<MobileServiceContext>
    //{
    //    protected override void Seed(MobileServiceContext context)
    //    {
    //        List<TodoItem> todoItems = new List<TodoItem>
    //        {
    //            new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
    //            new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
    //        };

    //        foreach (TodoItem todoItem in todoItems)
    //        {
    //            context.Set<TodoItem>().Add(todoItem);
    //        }

    //        base.Seed(context);
    //    }
    //}
}

