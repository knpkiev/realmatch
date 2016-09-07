using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace WebApplication1.Models
{
    public class Jobs
    {
        public long Id { get; set; }
        public long LuJobTitleId { get; set; }
        public string JobDescription { get; set; }
        public virtual LuJobTitle LuJobTitle { get; set; }
    }
}