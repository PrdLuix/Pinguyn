using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;
    public Image heartDisplay0;
    public Image heartDisplay1;
    public Image heartDisplay2;

    bool isPause;
    public Text neveText;
    void Pause()
    {
        Time.timeScale = 0;
    }
    void UnPause()
    {
        Time.timeScale = 1;
    }
    public void VidasUpdate(int vida)
    {
        switch (vida)
        {
            case 0:
                heartDisplay0.sprite = lives[0];
                heartDisplay1.sprite = lives[0];
                heartDisplay2.sprite = lives[0];
                break;
            case 1:
                heartDisplay0.sprite = lives[1];
                heartDisplay1.sprite = lives[0];
                heartDisplay2.sprite = lives[0];
                break;
            case 2:
                heartDisplay0.sprite = lives[1];
                heartDisplay1.sprite = lives[1];
                heartDisplay2.sprite = lives[0];
                break;
            case 3:
                heartDisplay0.sprite = lives[1];
                heartDisplay1.sprite = lives[1];
                heartDisplay2.sprite = lives[1];
                break;
        }
            
    }
    public void NeveUpdate(int bolas)
    {
        neveText.text = bolas.ToString();
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
