using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LerpRotationOnTimer : MonoBehaviour
    {
        [SerializeField] private Timer levelTimer;
        [SerializeField] private Transform[] children;
        [SerializeField] private Transform startRot, endRot;
        //Audio
        [SerializeField] private AudioManager audioManager;

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
            //Audio
            audioManager.changeMusicState(timeCount / levelTimer.maxTime);
            audioManager.changeAmbienceState(timeCount / levelTimer.maxTime);

            timeCount += Time.deltaTime;


            if (timeCount / levelTimer.maxTime >= 0.99) {
                audioManager.endMusic(1);
            }
        }

        private void LateUpdate()
        {
            for (int i = 0; i < children.Length; i++)
            {
                children[i].transform.rotation = Quaternion.Euler(0, 0, startChildrenRotations[i] + (-this.transform.rotation.z - 15));
            }
        }
    }