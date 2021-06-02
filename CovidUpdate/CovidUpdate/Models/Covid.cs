using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidUpdate.Models
{
    public class Covid
    {
        public Global Global { get; set; }
        public List<Countries> Countries { get; set; }

    }
}