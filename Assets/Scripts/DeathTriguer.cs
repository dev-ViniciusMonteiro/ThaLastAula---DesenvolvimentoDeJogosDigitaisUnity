using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTriguer : MonoBehaviour
{

    // OnTriggerEnter2D � chamado quando outro Collider2D entra no gatilho (somente f�sica de 2D)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("caiu Triguer");
            SceneManager.LoadScene("SampleScene");
        }
    }

}
