﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] float velocidade;
    Transform player;
    Rigidbody2D rb;
    [SerializeField] bool turnRight;
    private Transform tr;
    public bool acordado;
    BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        acordado = true;
        turnRight = false;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        tr = GetComponent<Transform>();
    }
    void Flip()
    {
        turnRight = !turnRight;
        tr.localScale = new Vector2(-tr.localScale.x, tr.localScale.y);
    }
    void Update()
    {
        if (acordado)
        {
            if ((transform.position.x < player.transform.position.x) && turnRight == false)
            {
                Flip();
            }
            else if (transform.position.x > player.transform.position.x && turnRight)
            {
                Flip();
            }
            if (transform.position.x < player.transform.position.x && velocidade < 0)
            {
                velocidade *= -1;
            }
            else if (transform.position.x > player.transform.position.x && velocidade > 0)
            {
                velocidade *= -1;
            }
        }
        //se desacordado mudar animação

    }
    private void FixedUpdate()
    {
       if(acordado)
            rb.velocity = new Vector2(velocidade, rb.velocity.y);
    }
    public IEnumerator Desacordar()
    {
        
        acordado = false;
        rb.gravityScale = 0;
        boxCollider.isTrigger = true;
        yield return new WaitForSeconds(5.0f);
        boxCollider.isTrigger = false;
        rb.gravityScale = 1f;
        acordado = true;
    }
    

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerControl>().PerderVida(); 
        }
        if (other.gameObject.CompareTag("Tiro"))
        {
            Destroy(other.gameObject);
            StartCoroutine(Desacordar());
        }
    }
}