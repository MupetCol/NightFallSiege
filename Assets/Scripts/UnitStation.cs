using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class UnitStation : MonoBehaviour
    {
        [SerializeField] private float cooldown = 1f;

        private bool canBeOccupied = true;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!canBeOccupied) return;
            
            if (other.TryGetComponent(out Unit unitScript))
            {
                if (unitScript.canOccupyStation)
                {
                    canBeOccupied = false;
                    unitScript.WasDestroyed += RenableStation;
                    unitScript.cantMove = true;
                    unitScript.rb.velocity = Vector3.zero;
                }
            }
        }

        private void RenableStation()
        {
            StartCoroutine(RenableStationCor());
        }

        private IEnumerator RenableStationCor()
        {
            Debug.Log("Renablin station " + this.gameObject.name);
            yield return new WaitForSeconds(cooldown);
            canBeOccupied = true;
            Debug.Log("Renabled station " + this.gameObject.name);
        }
    }