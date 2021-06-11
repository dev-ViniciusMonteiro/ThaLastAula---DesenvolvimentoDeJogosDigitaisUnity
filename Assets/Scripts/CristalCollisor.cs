using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalCollisor : MonoBehaviour
{
    public Playercontroller player;//colocar player referencia no editor
    public AudioSource Audio;
    private void Start()
    {
        Audio.Stop();
    }

    // OnTriggerEnter2D é chamado quando outro Collider2D entra no gatilho (somente física de 2D)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.AddCristal();
            Audio.Play();
            Destroy(gameObject);
        }
    }

}
