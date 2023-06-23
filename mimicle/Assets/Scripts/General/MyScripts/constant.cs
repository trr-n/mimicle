using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mimical
{
    public static class Constant
    {
        public enum sindex
        {
            Title = 0,
            Main = 1
        }

        public static readonly string
        //------------------------------------------------------------------------------
        // SCENE NAME
        //------------------------------------------------------------------------------
        Main = "Main",
        Title = "Title";

        //------------------------------------------------------------------------------
        // KEY NAME?
        //------------------------------------------------------------------------------
        public static readonly string
        Horizontal = "Horizontal",
        Vertical = "Vertical",
        Fire = "Fire",
        Reload = "Reload",
        Jump = "Jump",
        MouseX = "Mouse X",
        MouseY = "Mouse Y",
        Volume = "Volume";

        //------------------------------------------------------------------------------
        // TAG NAME
        //------------------------------------------------------------------------------
        public static readonly string
        Player = "Player",
        Enemy = "Enemy",
        Safety = "LifeZone",
        Dark = "Dark",
        Manager = "Manager",
        Charger = "Charger",
        LilC = "LilC",
        Bullet = "Bullet",
        Logo = "Logo",
        Boss = "Boss",
        TriggerZone = "TriggerArea";
    }
}

// Space || A = Fire,
// LShift || B = Reload,
// WASD || LStick = Moving
