using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text vidaText;

    public void PerderVidas(int vidas)
    {

        vidaText.text = "Vida: " + vidas;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}
