using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class TopDownCharacterController : MonoBehaviour
    {

        public static TopDownCharacterController instance;

        public int currentHealth;
        public int maxHealth = 3;


    public GameObject objectToDestroy;

        public float speed;

        private Animator animator;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            currentHealth = maxHealth;
            animator = GetComponent<Animator>();
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.Q))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.Z))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }

    public void TakeDamage(int damage)
    {
   
        if (currentHealth >= 0)
        {
            currentHealth -= damage;
        }
        
    }

    public void die()
    {
        if (currentHealth <= 0)
        {
            Destroy(objectToDestroy);
        }
    }
 }

