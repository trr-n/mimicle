using UnityEngine;

namespace Mimical
{
    public class Wave : MonoBehaviour
    {
        [SerializeField]
        int max = 3;

        public int Max => max;

        [SerializeField]
        int now = 0;

        public int Now => now;

        public static int First = 0, Second = 1, Third = 2;

        public float Progress => now / max;

        public void Next() => now++;

        public void Set(int wave) => now = wave + 1;

        void Reset() => now = 0;
    }
}
