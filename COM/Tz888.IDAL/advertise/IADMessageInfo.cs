using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.advertise;
using System.Data;

namespace Tz888.IDAL.advertise
{
    public interface IADMessageInfo
    {
        long AddMessage(ADMessageInfo message);
        long UpdateMessage(ADMessageInfo message, int id);
        DataView SelChange();
        string TypdName(int id);
        string SelName(int bid);
        ADMessageInfo SelMessage(int id);

        long DelMessage(int id);
    }
}
