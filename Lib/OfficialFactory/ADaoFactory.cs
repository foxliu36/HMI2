using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Factory;

namespace Lib.OfficialFactory
{
    public abstract class ADaoFactory
    {


        abstract InterfaceDao getInstance(string p_Type);
    }
}
