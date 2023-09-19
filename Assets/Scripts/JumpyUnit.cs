using System;
using UnityEngine;

    public class JumpyUnit : Unit
    {
        [SerializeField] private int maxTriggeredAmount;
        [SerializeField] private float pushStrength = 1f;
        [SerializeField] private bool isPlaced;
        [SerializeField] private GameObject trigger;
        
        private int triggerCount = 0;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("JumpTrigger"))
            {
                pushStrength = other.GetComponent<JumpyTrigger>().strength;
                cantMove = true;
                isPlaced = true;
                trigger.SetActive(false);
            }
            
            if (other.transform.parent.TryGetComponent(out ITrampolineable unitScript))
            {
                if (!isPlaced) return;

                if (unitScript.CanJump(gameObject)) return;
                
                triggerCount++;
                unitScript.Jump(pushStrength, gameObject);
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