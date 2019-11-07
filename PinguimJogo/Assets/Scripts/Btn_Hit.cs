using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Btn_Hit : MonoBehaviour
{
    public AudioClip overFX;
    public AudioClip clickFX;
    private AudioSource myFX;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        myFX = GetComponent<AudioSource>();
    }
    public void OverSound()
    {
        myFX.PlayOneShot(overFX);
    }
    public void ClickSound()
    {
        myFX.PlayOneShot(clickFX);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
