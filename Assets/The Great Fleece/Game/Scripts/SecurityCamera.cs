using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public GameObject gameOver;
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            MeshRenderer render = GetComponent<MeshRenderer>();
            Color32 color = new Color32(255, 0, 2, 10);
            render.material.SetColor("_TintColor", color);
            animator.enabled = false;
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        gameOver.SetActive(true);
    }
}
