using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour
{

    private GameObject[] bgs;
    private float _distancia;
    private float _distandia_pos;

    void Awake()
    {
        bgs = GameObject.FindGameObjectsWithTag("BG");
    }

    // Start is called before the first frame update
    void Start()
    {
        _distancia = bgs[0].GetComponent<BoxCollider2D>().bounds.size.x;
        _distandia_pos = bgs[0].transform.position.x;

        for(int i = 1; i<bgs.Length; i++)
        {
            if(bgs[i].transform.position.x> _distandia_pos)
            {
                _distandia_pos = bgs[i].transform.position.x;
            }
        }
    }

    // OnTriggerEnter2D é chamado quando outro Collider2D entra no gatilho (somente física de 2D)
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "BG")
        {
            if(collision.transform.position.x >= _distandia_pos)
            {
                Vector3 temp = collision.transform.position;
                for(int i = 0; i < bgs.Length; i++)
                {
                    if (!bgs[i].activeInHierarchy)
                    {
                        temp.x += _distancia;
                        bgs[i].transform.position = temp;
                        bgs[i].gameObject.SetActive(true);

                        _distandia_pos = temp.x;
                    }
                }
            }
        }
    }

   
}
