using System;
using UnityEngine;

    public class KillerBarrier : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(other.gameObject);
        }
    }