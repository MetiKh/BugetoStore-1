﻿using Microsoft.AspNetCore.Mvc;
using MyStore.Application.Services.Common.IGetMenuService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.ViewComponents
{
    public class GetMenu:ViewComponent
    {
        IGetMenuItemService _getMenuItemService;
        public GetMenu(IGetMenuItemService getMenuItemService)
        {
            _getMenuItemService = getMenuItemService;
        }

        public IViewComponentResult Invoke()
        {
            var Categories = _getMenuItemService.Execute();
            return View(viewName:"GetMenu",model:Categories.Data);
        }

    }
}
