﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult AuctionDetails(int AuctionID)
        {
            return View();
        }
        public ActionResult AuctionList()
        {
            return View();
        }
    }
}
