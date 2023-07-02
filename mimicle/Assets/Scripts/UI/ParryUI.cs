using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mimical
{
    public class ParryUI : MonoBehaviour
    {
        [SerializeField]
        Parry parry;
        [SerializeField]
        Text timer;

        void Update()
        {
            timer.text = parry.Timer.ToString();
        }
    }
}