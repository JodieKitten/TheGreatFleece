using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinActivation : MonoBehaviour
{

    public GameObject winScene;
    public GameObject message;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && GameManager.Instance.HasCard == true)
        {
            winScene.SetActive(true);
        }
        else if(other.tag == "Player" && GameManager.Instance.HasCard != true)
        {
            message.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        message.SetActive(false);
    }
}
