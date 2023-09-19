using System;
using System.Collections.Generic;
using UnityEngine;

    public class AttackUnit : Unit
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.TryGetComponent(out EnemyBase enBase))
            {
                enBase.hitPoints--;
                Destroy(gameObject);
            }
        }
    }