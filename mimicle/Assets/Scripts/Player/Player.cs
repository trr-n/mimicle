using UnityEngine;
using Feather.Utils;

namespace Feather
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField]
        Ammo ammo;
        [SerializeField]
        Fire gun;
        [SerializeField]
        GameManager manager;
        [SerializeField]
        AudioClip[] damageSE;
        [SerializeField]
        Parry parry;
        [SerializeField]
        CircleUI circleUI;

        // Gun
        const float RapidSpan = 0.1f;
        float time2reload = 0f;
        public float Time2Reload => time2reload;
        bool isReloading = false;
        public bool IsReloading => isReloading;
        public float ReloadProgress;
        float movingSpeed = 5;
        HP hp;
        RaycastHit2D hit;
        Stopwatch reloadSW = new();
        Stopwatch rapidSW = new(true);
        Stopwatch sw = new();
        SpriteRenderer sr;
        new BoxCollider2D collider;
        public bool NotNinnin = false;
        public RaycastHit2D Hit => hit;
        public float Reload__ => reloadSW.SecondF(2);
        const float MaxReloadTime = 1f;
        public float ratio = 0f;

        void Awake()
        {
            hp = GetComponent<HP>();
            manager ??= Gobject.Find(Constant.Manager).GetComponent<GameManager>();
            sr = GetComponent<SpriteRenderer>();
            collider = GetComponent<BoxCollider2D>();
        }

        void Start()
        {
            ammo.Reload();
        }

        void Update()
        {
            Move();
            Dead();
            Reload();
            hit = Physics2D.Raycast(transform.position, Vector2.right, 20.48f, 1 << 9 | 1 << 10);
            collider.isTrigger = parry.IsParry;
            if (sw.sf >= 0.2f)
            {
                sr.color = Color.white;
            }
        }

        void FixedUpdate()
        {
            if (NotNinnin = !(Mynput.Pressed(Values.Key.Fire) && !ammo.IsZero() && rapidSW.sf > RapidSpan && !isReloading))
            {
                return;
            }
            gun.Shot();
            rapidSW.Restart();
        }

        void Reload()
        {
            ReloadProgress = reloadSW.sf / time2reload;
            if (!isReloading)
            {
                // リロード時間=残弾数の割合*n秒
                time2reload = (1 - ammo.Ratio) * MaxReloadTime;
            }

            if (Mynput.Down(Values.Key.Reload))
            {
                ratio = ammo.Ratio;
                ammo.Reload();
                isReloading = true;
            }

            if (isReloading)
            {
                reloadSW.Start();
                if (!(reloadSW.SecondF() >= time2reload))
                {
                    return;
                }
                isReloading = false;
                reloadSW.Reset();
            }
        }

        void Dead()
        {
            if (hp.IsZero)
            {
                manager.PlayerIsDead();
            }
        }

        void Move()
        {
            if (!manager.Ctrlable)
            {
                return;
            }

            transform.ClampPosition2(-7.95f, 8.2f, -4.12f, 4.38f);
            (float h, float v) axis = (Input.GetAxisRaw(Constant.Horizontal), Input.GetAxisRaw(Constant.Vertical));
            transform.Translate(new Vector2(axis.h, axis.v) * movingSpeed * Time.deltaTime);
        }

        void OnCollisionEnter2D(Collision2D _)
        {
            if (!parry.IsParry)
            {
                sw.Restart();
                sr.SetColor(Color.red);
            }
        }
    }
}
