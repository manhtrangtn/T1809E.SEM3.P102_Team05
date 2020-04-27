using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T1809E.SEM3.P102_Team05.Models.ModelRequires
{
    public class RequireModelGetAll
    {
        //string keyword, string sortType, string sortBy, int pageNumber, int pageSize
        public string keyword { get; set; }
        public string sortType { get; set; }
        public string sortBy { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }
}