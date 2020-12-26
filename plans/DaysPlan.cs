using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plans
{
    public class DaysPlan
    {
        public OnePlan[] Plan { get; set; }

        public DaysPlan()
        {
            Plan = new OnePlan[4];
            for (int i = 0; i < 4; i++)
                Plan[i] = new OnePlan();
        }
    }
}
