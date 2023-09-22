using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CatapultUnit : Unit
    {
        [SerializeField] private int maxTriggeredAmount;
        [SerializeField] public float pushStrength = 1f;
        [SerializeField] private GameObject trigger;
        
        private Animator animator;
        private float interactionLength;

        protected override void Awake()
        {
            base.Awake();
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            var clips = animator.runtimeAnimatorController.animationClips;
            foreach (var clip in clips)
            {
                switch (clip.name)
                {
                    case "CatapultInteraction":
                        interactionLength = clip.length;
                        break;
                    default:
                        break;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!canInteract) return;
            
            if (other.TryGetComponent(out ICatapultable unitScript))
            {
                if (unitScript.CanCatapult(gameObject)) return;

                canInteract = false;
                unitScript.Catapult(pushStrength, gameObject);
                StartCoroutine(InteractAndDie());
            }
        }

        private IEnumerator InteractAndDie()
        {
            animator.Play("CatapultInteraction");
            yield return new WaitForSeconds(interactionLength + .1f);
            Destroy(this.gameObject);
        }

        protected override void Update()
        {
            base.Update();
            // if (triggerCount >= maxTriggeredAmount)
            // {
            //     Destroy(this.gameObject);
            // }
        }
    }