using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Domain.Entities
{
    public class Menu
    {
        public int ID { get; set; }

        public int MenuCategoryID { get; set; }

        public string Name { get; set; }

        public string Discription { get; set; }

        public MenuCategory MenuCategory { get; set; }
      
    }
}
