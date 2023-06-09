using System;
using UnityEngine;
using Feather.Utils;
using DG.Tweening;

namespace Feather
{
    public sealed class LilC : Enemy
    {
        [SerializeField]
        GameObject bullet, fx;

        HP hp;
        Vector2 firstPosition;
        Vector2 direction;
        Stopwatch sw = new(true);
        float rapid = 2;

        void Start()
        {
            hp = GetComponent<HP>();
            base.Start(hp);
            Move();
        }

        One one = new();
        void Update()
        {
            Left(gameObject);

            if (sw.sf >= rapid)
            {
                bullet.Instance(transform.position + new Vector3(-0.75f, 0), Quaternion.identity);
                sw.Restart();
            }

            if (hp.IsZero)
            {
                AddSlainCountAndRemove(gameObject);
                Score.Add(Values.Point.LilC);
                one.RunOnce(() =>
                {
                    fx.Instance(transform.position);
                    GameObject.FindGameObjectWithTag(Constant.Player).TryGetComponent<HP>(out var playerHp);
                    playerHp.Healing(((int)MathF.Round((playerHp.Max - playerHp.Now) / 2, 0)));
                });
            }
        }

        protected override void Move()
        {
            firstPosition = new(Rnd.Int(3, 6), transform.position.y);
            direction = firstPosition - (Vector2)transform.position;
            transform.DOMove(firstPosition, 10).SetEase(Ease.OutCubic);
        }
    }
}
