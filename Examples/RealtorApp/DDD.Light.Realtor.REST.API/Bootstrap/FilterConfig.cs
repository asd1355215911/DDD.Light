﻿using System.Web.Mvc;

namespace DDD.Light.Realtor.REST.API.Bootstrap
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}