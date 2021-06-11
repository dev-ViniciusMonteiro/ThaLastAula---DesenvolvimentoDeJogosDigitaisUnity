using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPersiste : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
