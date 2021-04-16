using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTriguer : MonoBehaviour
{

    private int ParamPlayer = Animator.StringToHash("Player");


    // OnTriggerEnter2D é chamado quando outro Collider2D entra no gatilho (somente física de 2D)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("SampleScene");//ou ira para aba morto
        }
    }
    //se tiver colisao fora do mapa ou com algum lugar de morte volta ao comeco do jogo, mesmo que estiver na ultima fase (HARD)

}
