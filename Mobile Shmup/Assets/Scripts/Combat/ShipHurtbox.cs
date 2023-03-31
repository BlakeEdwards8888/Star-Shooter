using Shmup.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Combat
{
    public class ShipHurtbox : Hurtbox
    {
        protected override void CollisionEffect()
        {
            Health health = GetComponent<Health>();
            health.Death();
        }
    }
}
