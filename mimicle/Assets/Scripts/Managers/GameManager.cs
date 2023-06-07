using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mimical.Extend;

namespace Mimical
{
    public sealed class GameManager : MonoBehaviour
    {
        public static class Key
        {
            public static KeyCode Reload = KeyCode.LeftShift;

            public static KeyCode Fire = KeyCode.Space;

            public static KeyCode Mute = KeyCode.M;

            public static KeyCode Stop = KeyCode.Backspace;

            public static KeyCode VUp = KeyCode.UpArrow;

            public static KeyCode VDown = KeyCode.DownArrow;

            public static KeyCode ChangeSong = KeyCode.LeftArrow;
        }

        public static class Dmg
        {
            public static int Charger = 5;

            public static int LilC = 10;
        }

        public static class Point
        {
            public static int Charger = 100;

            public static int LilC = 500;

            public static int Boss = 10000;


            public static int RedCharger = -10;

            public static int RedLilC = -100;

            public static int RedLilCBullet = -10;

        }

        public GameObject menuPanel;

        [SerializeField]
        Text debugT;

        [SerializeField]
        Scroll scroll;

        [SerializeField]
        Slain slain;

        public bool PlayerCtrlable { get; set; }

        public bool BackGroundScrollable { get; set; }

        public bool IsOpeningMenu { get; set; }

        bool isPassing = true;
        public bool IsPassing => isPassing;

        void Start()
        {
            PlayerCtrlable = true;

            BackGroundScrollable = true;

            Physics2D.gravity = Vector3.forward * 9.81f;
        }

        void Update()
        {
            isPassing = Time.timeScale == 1;

            // debugT.text =
            //     "Scrollable: " + BackGroundScrollable.newline() +
            //     "Controllable: " + PlayerCtrlable.newline() +
            //     "isOpenMenu: " + IsOpeningMenu.newline() +
            //     "isSpent: " + isPassing.newline();

            debugT.text = "slain count: " + slain.Count;

            if (input.Pressed(Key.Stop))
            {
                Time.timeScale = 0;

                PlayerCtrlable = false;

                BackGroundScrollable = false;
            }

            else if (input.Up(Key.Stop))
            {
                Time.timeScale = 1;

                PlayerCtrlable = true;

                BackGroundScrollable = true;
            }
        }

        public void Pause()
        {
            menuPanel.SetActive(true);

            PlayerCtrlable = false;

            BackGroundScrollable = false;

            IsOpeningMenu = true;

            Time.timeScale = 0;
        }

        public void Restart()
        {
            menuPanel.SetActive(false);

            PlayerCtrlable = true;

            BackGroundScrollable = true;

            IsOpeningMenu = false;

            Time.timeScale = 1;
        }
    }
}
