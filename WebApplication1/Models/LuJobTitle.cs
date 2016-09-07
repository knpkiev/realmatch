using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class LuJobTitle
    {
        public long Id { get; set; }
        public string JobTitleText { get; set; }
        public virtual List<Jobs> Jobs { get; set; }
    }
}