using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalCollisor : MonoBehaviour
{
    public Playercontroller player;//colocar player referencia no editor
    // OnTriggerEnter2D � chamado quando outro Collider2D entra no gatilho (somente f�sica de 2D)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.AddCristal();
            Destroy(gameObject);
        }
    }

}
