using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedState : MonoBehaviour
{
    public Material selectedMaterial;
    private Material originalMaterial;
    public AudioClip audioClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        audioSource.clip = audioClip;
        originalMaterial = gameObject.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playAudio(){
        audioSource.Play();
    }
    public void setSelectedMaterial(){
        gameObject.GetComponent<MeshRenderer>().material = selectedMaterial; 
    }
    public void setOriginalMaterial(){
        gameObject.GetComponent<MeshRenderer>().material = originalMaterial; 
    }
}
