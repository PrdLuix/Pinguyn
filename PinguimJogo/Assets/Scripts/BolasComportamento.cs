using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolasComportamento : MonoBehaviour
{
    Rigidbody2D rb;
    Transform tr;
    [SerializeField]
    float forcaDoTiro;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //se virado para esquerda e no chao => atirar para esquerda
        //se virado para direita e no chao => atirar para direia
        //se pulando e virado para direita => atirar para diagonal direita
        //se pulando E virado para esquerda => atirar para diagonal esquerda
        //se pulando e segurando o botao do pulo => atirar para cima
        transform.Translate(Vector2.right);
    }
}
