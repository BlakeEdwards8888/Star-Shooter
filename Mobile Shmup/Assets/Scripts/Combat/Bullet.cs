using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shmup.Attributes;

namespace Shmup.Combat {
    public class Bullet : Hurtbox
    {
        [SerializeField] SpriteRenderer sprite;
        [SerializeField] bool destroyImmediate = false;

        protected override void CollisionEffect()
        {
            if (destroyImmediate)
                Destroy(gameObject);

            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Collider2D>().enabled = false;
            sprite.enabled = false;
            Destroy(gameObject, 1);
        }
    }
}
