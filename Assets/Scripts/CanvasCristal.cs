using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasCristal : MonoBehaviour
{
    public Playercontroller player;
    private GameObject cristal1;
    private GameObject cristal2;
    private GameObject cristal3;

    void Awake()
    {
        cristal1 = GameObject.FindGameObjectWithTag("crista1");
        cristal2 = GameObject.FindGameObjectWithTag("cristal2");
        cristal3 = GameObject.FindGameObjectWithTag("cristal3");
    }
 

    void Update()
    {
        
        if (player._cristal > 0)
        {
            if (player._cristal > 1)
            {
                add2();
            }
            if (player._cristal > 2)
            {
                add3();
            }
            add1();
        }
    }


    public void add1()
    {
        cristal1.gameObject.SetActive(false);

    }

    public void add2()
    {
        cristal2.gameObject.SetActive(false);

    }

    public void add3()
    {
        cristal3.gameObject.SetActive(false);
    }

}
