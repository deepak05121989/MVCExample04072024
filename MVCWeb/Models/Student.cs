using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;

namespace MVCWeb.Models
{
    public class Student
    {
        [Key]
        public string RoleNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string mobile { get; set; }

    }
}