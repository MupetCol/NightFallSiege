using System;
using Cinemachine;
using UnityEngine;

    public class UnitDestroyOnWall : MonoBehaviour
    {
        private void OnCollisionStay2D(Collision2D other)
        {
            Debug.Log(other.gameObject.tag);
            if (other.gameObject.CompareTag("Ground"))
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }