using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Unit : MonoBehaviour, ITrampolineable, ICatapultable
    {
        public bool canOccupyStation;
        public bool cantMove;
        
        [SerializeField] public float speed = 1f;
        [SerializeField] public float impulseCooldown = .2f;
        [SerializeField] public Vector3 jumpVector = new Vector3(.2f,1f,0);
        [SerializeField] public Vector3 catapultVector = new Vector3(1f,.5f,0);
        private float currentSpeed;
        [SerializeField] protected float killSelfThreshold = 1f; 
        [SerializeField] protected Transform groundCheck;
        
        protected List<GameObject> jumpies = new List<GameObject>();
        protected List<GameObject> catpults = new List<GameObject>();
        public Rigidbody2D rb;

        private bool killSelfOngoing = false;
        private bool checkForGround = false;
        private Collider2D wallCheckCollider;
        private Collider2D groundCheckCollider;

        public Action WasDestroyed;

        public bool CanJump(GameObject caster)
        {
            return jumpies.Contains(caster);
        }
        
        public bool CanCatapult(GameObject caster)
        {
            return catpults.Contains(caster);
        }

        void Awake()
        {
            currentSpeed = speed;
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (checkForGround)
            {
                groundCheckCollider = Physics2D.OverlapCircle(groundCheck.position, .1f);
                Debug.Log(groundCheckCollider.tag);
                if (groundCheckCollider.CompareTag("Ground"))
                {
                    cantMove = false;
                    checkForGround = false;
                }
            }
        }
        

        protected virtual void FixedUpdate()
        {
            if (cantMove) return;
            transform.Translate(Vector3.right/10f * currentSpeed);
            
            // if (killSelfOngoing) return;
            // wallCheckCollider = Physics2D.OverlapCircle(wallCheck.position, .1f);
            // if (wallCheckCollider.CompareTag("Ground"))
            // {
            //     StartCoroutine(KillSelf());
            // }
        }

        private void OnDestroy()
        {
            WasDestroyed?.Invoke();
        }

        // private IEnumerator KillSelf()
        // {
        //     killSelfOngoing = true;
        //     //if it ain touching the ground after threshold let it live
        //     
        //     yield return new WaitForSeconds(killSelfThreshold);
        //     
        //     var col = Physics2D.OverlapCircle(wallCheck.position, .1f);
        //     if (col.CompareTag("Ground"))
        //     {
        //         Destroy(this.gameObject);
        //     }
        //     else
        //     {
        //         killSelfOngoing = false;
        //         yield return null;
        //     }
        // }
        
        public void SlowDown()
        {
            currentSpeed = speed / 2;
        }

        public void Unslow()
        {
            currentSpeed = speed;
        }

        public virtual void Jump(float strength, GameObject jumpy)
        {
            if (jumpies.Contains(jumpy)) return;
            else
            {
                cantMove = true;
                rb.velocity = Vector3.zero;
                rb.AddForce(jumpVector * strength, ForceMode2D.Impulse);
                jumpies.Add(jumpy);
                StartCoroutine(LeaveGroundThreshold());
            }
        }

        private IEnumerator LeaveGroundThreshold()
        {
            yield return new WaitForSeconds(impulseCooldown);
            checkForGround = true;
        }

        public virtual void Catapult(float strength, GameObject jumpy)
        {
            if (catpults.Contains(jumpy)) return;
            else
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(catapultVector* strength, ForceMode2D.Impulse);
                catpults.Add(jumpy);
            }
        }
    }