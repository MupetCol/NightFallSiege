using System.Collections.Generic;
using UnityEngine;

    public class CatapultUnit : Unit
    {
        [SerializeField] private int maxTriggeredAmount;
        [SerializeField] private float pushStrength = 1f;
        [SerializeField] private bool isPlaced;
        [SerializeField] private GameObject trigger;
        
        private int triggerCount = 0;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("CatapultTrigger"))
            {
                cantMove = true;
                isPlaced = true;
                trigger.SetActive(false);
            }
            
            if (other.transform.parent.TryGetComponent(out ICatapultable unitScript))
            {
                if (!isPlaced) return;
                
                if (unitScript.CanCatapult(gameObject)) return;

                triggerCount++;
                unitScript.Catapult(pushStrength, gameObject);
            }
        }

        private void Update()
        {
            if (triggerCount >= maxTriggeredAmount)
            {
                Destroy(this.gameObject);
            }
        }
    }