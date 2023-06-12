using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mimical.Extend;

namespace Mimical
{
    public class LilCBullet : Bullet
    {
        float speed = 1;

        Transform playerTransform;
        Vector2 direction;

        void Start()
        {
            playerTransform = gobject.Find(constant.Player).transform;
            direction = playerTransform.position - transform.position;
        }

        void Update()
        {
            Move(speed);
        }

        protected override void Attack()
        {
            ;
        }
        protected override void Move(float speed)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }

        protected override void Attack(Collision2D info)
        {
            info.Get<HP>().Damage(Values.Damage.LilC);
            Score.Add(Values.Point.RedLilCBullet);

            gameObject.Remove();
        }

        void OnCollisionEnter2D(Collision2D info)
        {
            if (info.Compare(constant.Player))
            {
                Attack(info);
            }

            if (info.Compare(constant.Bullet))
            {
                gameObject.Remove();
            }
        }

        // void OnCollisionExit2D(Collision2D info)
        void OnTriggerExit2D(Collider2D info)
        {
            if (info.Compare(constant.Safety))
            {
                "removed".show();
                gameObject.Remove();
            }
        }
    }
}