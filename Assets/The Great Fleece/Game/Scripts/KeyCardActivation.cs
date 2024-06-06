using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardActivation : MonoBehaviour
{

    public GameObject keyCardCutscene;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            keyCardCutscene.SetActive(true);
            GameManager.Instance.HasCard = true;
            StartCoroutine(ReturnToPlay());
        }
    }

    IEnumerator ReturnToPlay()
    {
        yield return new WaitForSeconds(6.0f);
        keyCardCutscene.SetActive(false);
    }
}
