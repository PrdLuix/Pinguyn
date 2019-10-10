using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void ControleBotoes(string cenaDestino)
    {
        if (cenaDestino == "SampleScene")
        {
            Debug.Log("Jogo Iniciado");
        }
        SceneManager.LoadScene(cenaDestino);
    }
    public void SairJogo()
    {
        Application.Quit();
    }
}
