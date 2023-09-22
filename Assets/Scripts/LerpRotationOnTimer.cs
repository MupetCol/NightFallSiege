using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LerpRotationOnTimer : MonoBehaviour
    {
        [SerializeField] private Timer levelTimer;
        [SerializeField] private Transform[] children;
        [SerializeField] private Transform startRot, endRot;

        private List<float> startChildrenRotations = new List<float>();
        private float timeCount;

        private void Start()
        {
            foreach (var child in children)
            {
                startChildrenRotations.Add(child.localRotation.eulerAngles.z);
            }
        }

        private void Update()
        {
            
            
            transform.rotation = Quaternion.Lerp(startRot.rotation, endRot.rotation, timeCount/levelTimer.maxTime);
            timeCount += Time.deltaTime;
        }

        private void LateUpdate()
        {
            for (int i = 0; i < children.Length; i++)
            {
                children[i].transform.rotation = Quaternion.Euler(0, 0, startChildrenRotations[i] + (-this.transform.rotation.z - 15));
            }
        }
    }