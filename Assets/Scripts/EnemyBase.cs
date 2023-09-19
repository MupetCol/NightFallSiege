using System;
using UnityEngine;

    public class EnemyBase : MonoBehaviour
    {
        public int hitPoints = 5;

        private void Update()
        {
            if (hitPoints <= 0)
            {
                Debug.Log("Player Won");
            }
        }
    }