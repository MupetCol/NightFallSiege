using System;
using TMPro;
using UnityEngine;

    public class Timer : MonoBehaviour
    {
        public float maxTime;
        [SerializeField] private TMP_Text text;
        private bool timerOn = true;
        private float currTime;

        private void Awake()
        {
            currTime = maxTime;
        }

        private void Update()
        {
            if (timerOn)
            {
                if (currTime >= 0)
                {
                    currTime -= Time.deltaTime;
                    UpdateTime(currTime);
                }
                else
                {
                    timerOn = false;
                    currTime = 0;
                    UpdateTime(currTime);
                }

            }
        }

        private void UpdateTime(float time)
        {
            var minutes = Mathf.FloorToInt(currTime / 60);
            var seconds = Mathf.FloorToInt(currTime % 60);

            if (minutes > 0)
            {
                text.text = $"{minutes:0}:{seconds:00}";
            }
            else
            {
                text.text = $"{seconds:00}";
            }
        }
    }