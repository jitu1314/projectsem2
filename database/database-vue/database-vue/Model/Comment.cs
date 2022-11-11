using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace database_vue.Model
{
    public class Comment
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Review { get; set; }

        public int Rating { get; set; }
    }
}
