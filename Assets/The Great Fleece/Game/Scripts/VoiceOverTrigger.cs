using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{

    public AudioClip voiceOver;
    private bool _clipPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && _clipPlayed == false)
        {
            AudioManager.Instance.PlayVoiceOver(voiceOver);
            _clipPlayed = true;
        }
    }
}
