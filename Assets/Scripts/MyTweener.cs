using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyTweener : MonoBehaviour
{
    
    public enum PosRotSca {Position, Rotation, Scale}
    public PosRotSca whichTransform;
    bool isTweening;
    bool isPaused;
    public float tweenDuration;
    public Vector3 startFrom;
    public Vector3 endAt;
    private Vector3 currentAmount = Vector3.zero;

    void Start()
    {


    }

    IEnumerator TweenCoroutine()
    {
        isTweening = true;
        float t = 0.0f;
        Vector3 start = startFrom;
        Vector3 end = endAt;

        while (t < tweenDuration && isTweening)
        {
            t += Time.deltaTime;
            currentAmount = Vector3.Lerp(start, end, t / tweenDuration);
            yield return null;
        }
        isTweening = false;

    }

    void Update()
    {
        if (isTweening)
        {
            switch (whichTransform)
            {
                case PosRotSca.Position:
                    transform.localPosition = currentAmount;
                    break;
                case PosRotSca.Rotation:
                    transform.localRotation = Quaternion.Euler(currentAmount);
                    break;
                case PosRotSca.Scale:
                    transform.localScale = currentAmount;
                    break;
                default:
                    break;
            }   
        }   
    }

    public void StartTween()
    {
        if (!isTweening)
        {
            StartCoroutine(TweenCoroutine());
        }

    }
}

