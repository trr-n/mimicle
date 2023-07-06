using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Mimical
{
    public class ParamsUI : MonoBehaviour
    {
        [SerializeField]
        Image[] tops, bottoms;
        [SerializeField]
        HP hp_player;
        [SerializeField]
        Ammo ammo;

        void Update()
        {
            foreach (var i in tops)
                i.fillAmount = hp_player.Ratio;
        }

        public void UpdateAmmo()
        {
            foreach (var i in bottoms)
                i.fillAmount = ammo.Ratio;
        }
    }
}