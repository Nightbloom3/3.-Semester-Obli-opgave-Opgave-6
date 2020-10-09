using System;
using System.Collections.Generic;
using System.Text;
using FanLibrary;

namespace Opgave_6_TCP_server
{
    public static class FanList
    {
        public static List<FanOutPut> fanDataList = new List<FanOutPut>()
        {
            new FanOutPut("Lokale daw", 23, 44),
            new FanOutPut("lokale 55", 22, 43)
        };
    }
}
