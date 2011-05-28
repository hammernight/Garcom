using System.Collections.Generic;

namespace Garcom.Models
{
    public class Menu
    {
        public Menu() { Items = new List<MenuItem>(); }
        public IList<MenuItem> Items { get; set; }
    }

    public class MenuItem {}
}