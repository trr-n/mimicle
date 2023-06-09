﻿using static UnityEngine.SystemInfo;

namespace Feather.Utils
{
    public static class Sys
    {
        public static string OS() => operatingSystem;
        public static int RAM() => systemMemorySize / 1000;
        public static string CPU() => processorType;
        public static string GPU() => graphicsDeviceName.Space() + graphicsMemorySize / 1000 + "GB";
    }
}