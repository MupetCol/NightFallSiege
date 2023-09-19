using System.Collections.Generic;
using UnityEngine;

    public class Unit : MonoBehaviour, ITrampolineable, ICatapultable
    {
        
        [SerializeField] protected float speed = 1f;
        protected List<GameObject> jumpies = new List<GameObject>();
        protected List<GameObject> catpults = new List<GameObject>();
        protected bool cantMove;

        protected Rigidbody2D rb;


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
            rb = GetComponent<Rigidbody2D>();
        }
        
        protected virtual void FixedUpdate()
        {
            if (cantMove) return;
            
            transform.Translate(Vector3.right/10f * speed);
        }

        public virtual void Jump(float strength, GameObject jumpy)
        {
            if (jumpies.Contains(jumpy)) return;
            else
            {
                rb.AddForce(Vector3.up * strength, ForceMode2D.Impulse);
                jumpies.Add(jumpy);
            }
        }
        
        public virtual void Catapult(float strength, GameObject jumpy)
        {
            if (catpults.Contains(jumpy)) return;
            else
            {
                rb.AddForce(new Vector3(1,1,0)* strength, ForceMode2D.Impulse);
                catpults.Add(jumpy);
            }
        }
    }