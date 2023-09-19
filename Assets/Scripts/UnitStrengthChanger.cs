using System;
using UnityEngine;

    public class UnitStrengthChanger : MonoBehaviour
    {
        [SerializeField] private float newStrength = 0f;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out JumpyUnit unitScriptJum))
            {
                unitScriptJum.pushStrength = newStrength;
            }
            
            if (other.TryGetComponent(out CatapultUnit unitScriptCat))
            {
                unitScriptCat.pushStrength = newStrength;
            }
        }
    }