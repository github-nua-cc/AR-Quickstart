using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChanger : MonoBehaviour
{
    Dictionary<string, Material> originalMaterials = new Dictionary<string, Material>();
    List<GameObject> selectedGameObjects = new List<GameObject>();
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
                        selectedGameObjects.Add(go);
                        originalMaterials.Add(go.name, go.GetComponent<MeshRenderer>().material);
                        selectedState.playAudio();
                        go.GetComponent<MeshRenderer>().material = selectedState.material;
                }
            }
        }
        if (Input.touchCount > 0 && (Input.touches[0].phase == TouchPhase.Ended || /* Input.touches[0].phase == TouchPhase.Moved || */Input.touches[0].phase == TouchPhase.Canceled))
        {

                        for(int i = 0; i < selectedGameObjects.Count; i++){
                            selectedGameObjects[i].GetComponent<MeshRenderer>().material = originalMaterials[selectedGameObjects[i].name];
                            originalMaterials.Remove(selectedGameObjects[i].name);
                        }
                        selectedGameObjects.Clear();

        }
    }
}