using System;
using System.Collections;
using UnityEngine;

    public class JumpyUnit : Unit
    {
        [SerializeField] private int maxTriggeredAmount;
        [SerializeField] public float pushStrength = 1f;
        [SerializeField] private GameObject trigger;
         //Audio
        private GameObject audioManager;

    private int triggerCount = 0;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager");
    }

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
                audioManager.GetComponent<AudioManager>().playBounce();
                Destroy(this.gameObject);
            }
        }
    }