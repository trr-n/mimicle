using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Feather
{
    public class Final : MonoBehaviour
    {
        [SerializeField]
        Text scores;

        void Update()
        {
            scores.text = $"のこりじかん: {Score.finalTime}\nすこあ: {Score.finalScore}";
        }
    }
}
