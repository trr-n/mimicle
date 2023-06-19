using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mimical.Extend;

namespace Mimical
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

        // Gun
        float rapid;
        float reloading = 2;
        float reloadingTimer = 0;
        bool isReloading = false;
        public float ReloadProgress => reloadingTimer / reloading;
        float movingSpeed = 5;
        HP hp;

        RaycastHit2D hit;
        public RaycastHit2D Hit => hit;

        void Awake()
        {
            hp = GetComponent<HP>();
            manager ??= gobject.Find(constant.Manager).GetComponent<GameManager>();
        }

        void Start() => ammo.Reload();

        void FixedUpdate()
        {
            Trigger();
        }

        void Update()
        {
            Move();
            Dead();
            Reload();
            DrawRaid();
        }

        void DrawRaid()
        {
            var r = new Ray(transform.position, Vector2.right);
            // Debug.DrawRay(ray.origin, ray.direction);
            hit = Physics2D.Raycast(r.origin, r.direction, 20.48f, 1 << 9);
            if (!hit.collider)
                return;
        }

#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, transform.localScale);
        }
#endif

        void Trigger()
        {
            rapid += Time.deltaTime;

            if (input.Pressed(Values.Key.Fire) && !ammo.IsZero() && rapid > 0.5f &&
                !isReloading)
            {
                gun.Shot();

                rapid = 0;
            }
        }

        void Reload()
        {
            if (input.Down(Values.Key.Reload))
            {
                ammo.Reload();
                isReloading = true;
            }

            if (isReloading)
            {
                reloadingTimer += Time.deltaTime;

                if (reloadingTimer >= reloading)
                {
                    isReloading = false;
                    reloadingTimer = 0;
                }
            }
        }

        // TODO 死んだときの処理
        void Dead()
        {
            if (hp.IsZero)
            {
                scene.Load();
            }
        }

        void Move()
        {
            transform.setpc2(-7.95f, 8.2f, -4.12f, 4.38f);

            float h = Input.GetAxis(constant.Horizontal);
            float v = Input.GetAxis(constant.Vertical);

            Vector2 moving = new(h, v);

            if (!manager.PlayerCtrlable)
            {
                return;
            }

            transform.Translate(moving * movingSpeed * Time.deltaTime);
        }
    }
}
