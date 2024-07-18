using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stolovai.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public bool IsHere { get; set; }
        public int IsHereInt
        {
            get
            {
                if (IsHere)
                    return 1;
                return 0;
            }
        }
        public string Here
        {
            get
            {
                if (IsHere)
                    return "В наличии";
                return "Нет в наличии";
            }
        }
    }
}
