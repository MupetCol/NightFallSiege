using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class UnitStation : MonoBehaviour
    {
        [SerializeField] private GameObject unit;
        [SerializeField] private float cooldown = 1f;

        private bool canBeOccupied = true;
        private bool hasInit = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!canBeOccupied) return;
            
            if (other.TryGetComponent(out Unit unitScript))
            {
                if (unitScript.canOccupyStation)
                {
                    hasInit = true;
                    unitScript.cantMove = true;
                    unit = unitScript.gameObject;
                    canBeOccupied = false;   
                }
            }
        }

        private void Update()
        {
            if (unit == null && hasInit)
            {
                StartCoroutine(RenableStation());
            }
        }

        private IEnumerator RenableStation()
        {
            yield return new WaitForSeconds(cooldown);
            canBeOccupied = true;
        }
    }