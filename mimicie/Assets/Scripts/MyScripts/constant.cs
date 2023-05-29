using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mimic
{
    public static class constant
    {
        public enum SceneIndex
        {
            Title = 0,
        }

        public static readonly string
        //------------------------------------------------------------------------------
        // SCENE NAME
        //------------------------------------------------------------------------------
        Main = "Main"
        ;

        //------------------------------------------------------------------------------
        // KEY NAME?
        //------------------------------------------------------------------------------
        public static readonly string
        Horizontal = "Horizontal",
        Vertical = "Vertical",
        Jump = "Jump",
        MouseX = "Mouse X",
        MouseY = "Mouse Y",
        Volume = "Volume"
        ;

        //------------------------------------------------------------------------------
        // TAG NAME
        //------------------------------------------------------------------------------
        public static readonly string
        Player = "Player"
        ;

    }
}
