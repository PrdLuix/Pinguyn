using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    bool isPause;
    public Text vidaText;
    void Pause()
    {
        Time.timeScale = 0;
    }
    void UnPause()
    {
        Time.timeScale = 1;
    }
    public void PerderVidas(int vidas)
    {

        vidaText.text = "Vida: " + vidas;
    }

    void Start()
    {
        isPause = false;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;

            if (isPause)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }
    }
}
