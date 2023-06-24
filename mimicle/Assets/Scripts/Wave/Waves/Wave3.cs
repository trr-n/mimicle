using UnityEngine;

namespace Mimical
{
    public class Wave3 : MonoBehaviour
    {
        [SerializeField]
        WaveData data;
        // [SerializeField]
        // GameObject bossObj;
        [SerializeField, Tooltip("0:charger\n1:lilc\n2:slilc\n3:spide")]
        GameObject[] mobs;
        // [SerializeField]
        // GameObject uis;
        [SerializeField]
        GameObject[] bossRelated;
        [SerializeField]
        GameObject boss;

        Transform playerTransform;

        void Start()
        {
            foreach (var i in bossRelated)
                i.SetActive(false);
            // bossObj.SetActive(false);
            // uis.SetActive(false);
        }

        void OnEnable()
        {
            playerTransform = GameObject.FindGameObjectWithTag(Constant.Player).transform;
        }

        void Update()
        {
            Spawn();
            if (boss.GetComponent<HP>().IsZero)
                data.IsDone = true;
        }

        bool once = true;
        void Spawn()
        {
            if (data.Now != 3)
                return;
            print("wave3");
            transform.position = new();
            if (once)
            {
                foreach (var i in bossRelated)
                    i.SetActive(true);
                once = false;
            }
        }
    }
}
