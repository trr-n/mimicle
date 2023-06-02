﻿using UnityEngine;

namespace Mimical.Extend
{
    public static class input
    {
        public static bool Down() => Input.anyKeyDown;
        public static bool Down(int mouse) => Input.GetMouseButtonDown(mouse);
        public static bool Down(KeyCode key) => Input.GetKeyDown(key);
        public static bool Down(string name) => Input.GetButtonDown(name);

        public static bool Pressed() => Input.anyKey;
        public static bool Pressed(int mouse) => Input.GetMouseButton(mouse);
        public static bool Pressed(KeyCode key) => Input.GetKey(key);
        public static bool Pressed(string name) => Input.GetButton(name);

        public static bool Up(int mouse) => Input.GetMouseButtonUp(mouse);
        public static bool Up(KeyCode key) => Input.GetKeyUp(key);
        public static bool Up(string name) => Input.GetButtonUp(name);
    }
}