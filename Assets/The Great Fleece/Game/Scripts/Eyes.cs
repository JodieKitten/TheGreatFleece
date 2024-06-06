using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    
    public GameObject _gameOver;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _gameOver.SetActive(true);
        }
    }
}
