using System;
using System.Collections.Generic;

namespace GlobalVariables
{
    public static class Globals
    {
        public const String sparcVersion = "0.5.3"; // Current Sparc version
        public static LinkedList<Player> GlobalPlayerCache = new LinkedList<Player>();
    }
}