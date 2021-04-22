using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTriguer : MonoBehaviour
{
    public Playercontroller player;//colocar player referencia no editor
    public float timeKill = 1.1f;
    // OnTriggerEnter2D é chamado quando outro Collider2D entra no gatilho (somente física de 2D)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.Kill();
            StartCoroutine(DeathStop());
        }
    }

    IEnumerator DeathStop()
    {
        yield return new WaitForSeconds(timeKill);
        SceneManager.LoadScene("menu");
    }
    //se tiver colisao fora do mapa ou com algum lugar de morte volta ao comeco do jogo, mesmo que estiver na ultima fase (HARD)

}
