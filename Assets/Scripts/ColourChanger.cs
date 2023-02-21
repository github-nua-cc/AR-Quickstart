using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    Dictionary<string, Material> originalMaterials = new Dictionary<string, Material>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                SelectedState selectedState = hit.collider.gameObject.GetComponent<SelectedState>(); 
                if (hit.collider != null && selectedState != null)
                {
                        GameObject go = hit.collider.gameObject;
                        originalMaterials.TryAdd(go.name, go.GetComponent<MeshRenderer>().material);
                        selectedState.playAudio();
                    
                    go.GetComponent<MeshRenderer>().material = selectedState.material;
                }
            }
        }
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    GameObject go = hit.collider.gameObject;
                    go.GetComponent<MeshRenderer>().material = originalMaterials[go.name];
                }
            }
        }
    }
}