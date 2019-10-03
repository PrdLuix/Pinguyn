using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    Animator anim;
    PlayerControl player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<PlayerControl>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.vidas < 1)
        {
            anim.SetBool("Morte", true);
        }
    }
    
}
