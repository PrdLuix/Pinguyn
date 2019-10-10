using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform alvo;
    public float velocidadeRelativa;
    float posicaoAntX;
    void Start()
    {
        if (velocidadeRelativa < 1)
            velocidadeRelativa = 1;

        alvo = GameObject.FindGameObjectWithTag("Player").transform;

        posicaoAntX = alvo.position.x;
    }
    void EfeitoParallax()
    {
        transform.Translate((alvo.position.x - posicaoAntX) / velocidadeRelativa, 0, 0);

        posicaoAntX = alvo.position.x;
    }

    void Update()
    {
        EfeitoParallax();
    }
}
