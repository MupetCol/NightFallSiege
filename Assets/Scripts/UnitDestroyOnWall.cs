using System;
using Cinemachine;
using UnityEngine;

    public class UnitDestroyOnWall : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(other.gameObject.tag);
            if (other.gameObject.CompareTag("UnitDestroyer"))
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }