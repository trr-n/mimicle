using UnityEngine;
using UnityEngine.UI;
using Mimical.Extend;

using static Mimical.Extend.Sys;

namespace Mimical
{
    public class EscMenu : MonoBehaviour
    {
        [SerializeField]
        Text todayT;
        [SerializeField]
        Text systemT;
        [SerializeField]
        Text volumeT;
        [SerializeField]
        Text songT;
        [SerializeField]
        Speaker speaker;
        [SerializeField]
        GameManager manager;

        string[] info;

        void Start()
        {
            info = new string[] { OS(), CPU(), GPU(), RAM().ToString() };
        }

        void Update()
        {
            speaker.SpeakerVolumeControl(volumeT);
            if (Mynput.Down(Values.Key.Mute))
            {
                speaker.MuteVolume(volumeT);
            }
            if (Mynput.Down(Values.Key.MChange))
            {
                speaker.Change(songT);
            }

            if (Mynput.Down(KeyCode.Escape))
            {
                if (!manager.menuPanel.IsActive(Active.Hierarchy))
                {
                    todayT.text = "きょうは" + Temps.Date();
                    systemT.text =
                        "すぺっく".newline() +
                        "OS: " + info[0].newline() +
                        "CPU: " + info[1].newline() +
                        "GPU: " + info[2].newline() +
                        "RAM: " + info[3] + "GB";
                    manager.OpenMenu();
                    return;
                }
                manager.CloseMenu();
            }
        }
    }
}
