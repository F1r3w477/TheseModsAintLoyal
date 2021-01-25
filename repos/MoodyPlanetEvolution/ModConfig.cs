using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodyPlanetEvolution
{
    class ModConfig
    {
        public int seed { get; set; } = (int)(DateTime.Now.Ticks & 0x0000FFFF);
    }
}