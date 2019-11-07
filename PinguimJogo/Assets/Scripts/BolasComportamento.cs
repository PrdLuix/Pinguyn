using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolasComportamento : MonoBehaviour
{
    Rigidbody2D rb;
    Transform tr;
    [SerializeField]
    float direcaoDoTiro;
    PlayerControl player;
    Inimigo inimigo;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
        inimigo = GameObject.Find("Inimigo").GetComponent<Inimigo>();
        if (player.TurnRight)
        {
            direcaoDoTiro = 1;
        }
        else
        {
            direcaoDoTiro = -1;
        }
        
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
    }
    void Update()
    {
        transform.Translate(Vector2.right * direcaoDoTiro);
    }
}