using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] float velocidade;
    Transform player;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {    
        if (transform.position.x < player.transform.position.x && velocidade < 0)
        {
            velocidade *= -1;
        }
        else if(transform.position.x > player.transform.position.x && velocidade > 0)
        {
            velocidade *= -1;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(velocidade, rb.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerControl>().PerderVida(); 
        }
    }
}
