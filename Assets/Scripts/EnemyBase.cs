using System;
using TMPro;
using UnityEngine;

    public class EnemyBase : MonoBehaviour
    {
        public int hitPoints = 0;
        public int maxHitPoints = 5;
        [SerializeField] private TMP_Text indicatorText;

        private void Awake()
        {
            indicatorText.text = hitPoints + "/" + maxHitPoints;
        }

        private void Update()
        {
            if (hitPoints >= maxHitPoints)
            {
                Debug.Log("Player Won");
            }
        }

        public void BaseHit()
        {
            hitPoints++;
            indicatorText.text = hitPoints + "/" + maxHitPoints;
        }
    }