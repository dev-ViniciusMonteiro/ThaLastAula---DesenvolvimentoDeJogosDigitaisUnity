using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : MonoBehaviour
{

    // OnTriggerEnter2D é chamado quando outro Collider2D entra no gatilho (somente física de 2D)
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "BG")
        {
            target.gameObject.SetActive(false);
        }
    }

}
