using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Btn_Hit : MonoBehaviour
{
    public AudioSource myFX;
    public AudioClip overFX;
    public AudioClip clickFX;
    [SerializeField]int id;



    // Start is called before the first frame update
    void Start()
    {

    }
    public void OverSound()
    {
        myFX.PlayOneShot(overFX);
    }
    public void ClickSound()
    {
        myFX.PlayOneShot(clickFX);
    }
    // Update is called once per frame
    void Update()
    {
        //OverSound();
        //ClickSound();
    }
    public void OnSelect(BaseEventData eventData)
    {
        switch (id)
        {
            case 0:OverSound();
                //tocar som do player
                break;
            case 1: ClickSound();
                //tocar som dozoto
                break;
        }
    }
}
