using Sharpente.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpente.Interfaces
{
    interface ITouchable
    {
        public bool Touches(Point point);
    }
}
