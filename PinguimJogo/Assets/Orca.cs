using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class Orca : MonoBehaviour
{
    Animator animOrca;
   
    public Animation orcaJorrada;
        Transform jato;
        public GameObject player;
        Rigidbody2D rbp;
        bool onTop = false;
        public float jatoForce;
        bool canJato = false;
        float nextJato;
        public float minRandom;
        public float maxRandom;
        void Awake()
        {
            rbp = player.GetComponent<Rigidbody2D>();
            jato = gameObject.transform.GetChild(0);
            nextJato = Time.time + Randoma();
        animOrca = this.GetComponent<Animator>();
        }

        void FixedUpdate()
        {
            if (nextJato <= Time.time)
            {
                nextJato = Time.time + Randoma();
                if (canJato)
                {
                    rbp.AddForce(Vector2.up * jatoForce);
                }
            animOrca.SetBool("Sla", true);
            StartCoroutine(PararAnimacao());
            }
        }
         public IEnumerator PararAnimacao()
         {
        yield return new WaitForSeconds(0.7f);
        animOrca.SetBool("Sla", false);
    }


        void OnCollisionEnter2D(Collision2D o)
        {
            if (o.gameObject.tag == "Player")
            {
                canJato = true;
            }
        }

        private void OnCollisionExit2D(Collision2D o)
        {
            if (o.gameObject.tag == "Player")
            {
                canJato = false;
            }
        
        }

        public float Randoma()
        {
            return Random.Range(minRandom, maxRandom);
        }
    }

