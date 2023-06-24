using UnityEngine;
using Mimical.Extend;

namespace Mimical
{
    public enum Activate { First, Second, Third }
    public class WaveData : MonoBehaviour
    {
        [SerializeField]
        public Activate waves = Activate.First;
        [SerializeField]
        GameObject[] waveObjs;

        int max = 0;
        public int Max => max;
        int now4ui = 0;
        public int Now => now4ui;
        public bool IsDone { get; set; }

        void Start()
        {
            max = waveObjs.Length;
            now4ui = ((int)waves);
            ActivateWave(((int)waves));
        }

        bool b = true;
        void Update()
        {
            // now = ((int)waves) + 1;
            if (SelfInput.Down(KeyCode.Return))
                Next();
            if (IsDone && b)
            {
                b = false;
                // }
                // if (SelfInput.Down(0))
                // {
                Score.StopTimer();
                Score.finalScore = Score.Now;
                Score.finalTime = Score.Time();
            }
            print("score: " + Score.finalScore + ", time: " + Score.finalTime);
        }

        public void Next()
        {
            now4ui = ((int)waves) + 1;
            waveObjs[now4ui - 1].SetActive(true);
            for (int i = 0; i < waveObjs.Length; i++)
                if (now4ui - 1 != i)
                    waveObjs[i].SetActive(false);
        }

        public void ActivateWave(int index)
        {
            waveObjs[index].SetActive(true);
            now4ui = index + 1;
            for (var i = 0; i < waveObjs.Length; i++)
                if (i != index)
                    waveObjs[i].SetActive(false);
        }
    }
}
