using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData){
        GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
    }
}
