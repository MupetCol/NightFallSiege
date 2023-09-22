using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

    public class LevelSequencer : MonoBehaviour
    {
        [SerializeField] private GameObject[] objectsToEnable;
        [SerializeField] private float lerpZoomTime, lerpMovementTime;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        private LerpRotationOnTimer skyRotation;
        private float zoomTimer, posTimer;
        private bool doZoom, doMove;
        private Camera cam;
        
        public float startZoom, endZoom;
        public Transform start, end;

        private void Awake()
        {
            cam = Camera.main;
            skyRotation = FindObjectOfType<LerpRotationOnTimer>();
        }

        public void StartGame()
        {
            LerpCameraPos();
            LerpCameraZoom();
        }

        private void LerpCameraZoom()
        {
            zoomTimer = 0;
            doZoom = true;
        }

        private void LerpCameraPos()
        {
            posTimer = 0;
            doMove = true;
        }

        private void FixedUpdate()
        {
            if(doMove)
            {
                if (lerpMovementTime > posTimer)
                {
                    cam.transform.position = Vector3.Lerp(start.position, end.position, posTimer / lerpMovementTime);
                    posTimer += Time.deltaTime;
                }
                else
                {
                    doMove = false;
                    posTimer = lerpMovementTime;
                    cam.transform.position = Vector3.Lerp(start.position, end.position, posTimer / lerpMovementTime);
                }
            }
            
            if(doZoom)
            {
                if (lerpZoomTime > zoomTimer)
                {
                    virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(startZoom, endZoom, zoomTimer / lerpMovementTime);
                    zoomTimer += Time.deltaTime;
                }
                else
                {
                    doMove = false;
                    zoomTimer = lerpZoomTime;
                    virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(startZoom, endZoom, zoomTimer / lerpMovementTime);
                    EnableObjects();
                }
            }
        }

        private void EnableObjects()
        {
            foreach (var obj in objectsToEnable)
            {
                obj.SetActive(true);
            }

            skyRotation.enabled = true;
        }
    }