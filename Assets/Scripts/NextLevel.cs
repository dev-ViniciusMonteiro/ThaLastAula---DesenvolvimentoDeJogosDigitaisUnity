using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public Playercontroller player;//colocar player referencia no editor
    // OnTriggerEnter2D é chamado quando outro Collider2D entra no gatilho (somente física de 2D)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player._cristal >= 3)
            {
                print("Proximo mapa");
                SceneManager.LoadScene("SampleScene");//Proximo Mapa
            }
        }
    }
}
