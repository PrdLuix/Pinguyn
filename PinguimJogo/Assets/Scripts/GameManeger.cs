using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{

    public static GameManeger gm;

    private int vidas = 2;
    // Start is called before the first frame update
    void Awake()
    {

        if (gm == null)
        {
            gm = this;
            DontDestroyOnLoad(gameObject);

        }
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetVidas(int vidas)
    {
        vidas += vidas;

    }
    public int GetVidas()
    {
        return vidas;
    }
}
