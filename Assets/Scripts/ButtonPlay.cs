using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Fase1");
    }
    public void tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
