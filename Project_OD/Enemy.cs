using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OD
{
    class Enemy:Entity
    {
        public Enemy() { }
        protected int target1;
        protected int target2;
        protected int triggerRange;


        public int Target1 { get => target1; set => target1 = value; }
        public int Target2 { get => target2; set => target2 = value; }
        public int TriggerRange { get => triggerRange; set => triggerRange = value; }
    }
}
