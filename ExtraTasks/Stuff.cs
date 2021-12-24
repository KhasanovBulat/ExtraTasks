using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraTasks
{
    //Stuff - это пища у человека, либо пища, которую забирает нечестЬ, либо подарок, которую дарит нечесть
    class Stuff
    {
        public string stuffType; //Тип пищи/подарка
        public double count; //кол-во

        public Stuff(string stuffType, double count)
        {
            this.stuffType = stuffType;
            this.count = count;
        }

        public override bool Equals(object obj)
        {
            Stuff stuff = (Stuff)obj;
            return stuffType.ToLower() == stuff.stuffType.ToLower() ;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
