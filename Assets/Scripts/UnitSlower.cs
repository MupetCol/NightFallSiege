using System;
using UnityEngine;

    public class UnitSlower : MonoBehaviour
    {
        [SerializeField] private Unit unit;

        private void Awake()
        {
            unit = transform.parent.GetComponent<Unit>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Ground"))
            {
                unit.SlowDown();
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Ground"))
            {
                unit.Unslow();
            }
        }
    }