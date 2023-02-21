using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedState : MonoBehaviour
{
    public Material material;
    public AudioClip audioClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        audioSource.clip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playAudio(){
        audioSource.Play();
    }
}
