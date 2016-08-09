using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSPJ
{
    public class result
    {
        private String name;
        private String industry;
        private String skill;


        public string Name { get; set; }
        public string Industry { get; set; }
        public string Skill { get; set; }
        public result()
        {
            this.name = name;
            this.industry = industry;
            this.skill = skill;
        }
        public virtual string toString()
        {
            String q = name + " " + Industry + " " + skill;
            return q;
        }
    }
    
    
    
}