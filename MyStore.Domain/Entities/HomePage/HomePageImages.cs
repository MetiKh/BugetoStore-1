﻿using MyStore.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Entities.HomePage
{
   public class HomePageImages:BaseEntity
    {
        public string Src { get; set; }
        public string Link { get; set; }
        public HomePageLocation PageLocation { get; set; }

    }
   public enum HomePageLocation
    {
        L1=0,
        L2=1,
        R1=2,
        CenterScreen=3,
        G1=4,
        G2=5
    }
}
