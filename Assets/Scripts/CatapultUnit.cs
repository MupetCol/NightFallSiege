using System.Collections.Generic;
using UnityEngine;

    public class CatapultUnit : Unit
    {
        [SerializeField] private int maxTriggeredAmount;
        [SerializeField] public float pushStrength = 1f;
        [SerializeField] private GameObject trigger;
        
        private int triggerCount = 0;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out ICatapultable unitScript))
            {
                if (unitScript.CanCatapult(gameObject)) return;

                triggerCount++;
                unitScript.Catapult(pushStrength, gameObject);
            }
        }

        protected override void Update()
        {
            base.Update();
            if (triggerCount >= maxTriggeredAmount)
            {
                Destroy(this.gameObject);
            }
        }
    }