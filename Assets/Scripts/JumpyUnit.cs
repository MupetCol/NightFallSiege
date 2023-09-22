using System;
using System.Collections;
using UnityEngine;

    public class JumpyUnit : Unit
    {
        [SerializeField] private int maxTriggeredAmount;
        [SerializeField] public float pushStrength = 1f;
        [SerializeField] private GameObject trigger;
        
        private int triggerCount = 0;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out ITrampolineable unitScript))
            {
                if (unitScript.CanJump(gameObject)) return;
                
                triggerCount++;
                unitScript.Jump(pushStrength, gameObject);
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