using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineMove : MonoBehaviour
{
    Coroutine mainCoroutine;
    Coroutine moveCoroutine;
    Coroutine rotateCoroutine;

    private void Start()
    {
        // StartCoroutine의 return은 Coroutine이다.
        mainCoroutine = StartCoroutine(MainCoroutine());
    }

    public void CoroutineStopButton()
    {
        if(mainCoroutine != null)  StopCoroutine(mainCoroutine);
        if(rotateCoroutine != null) StopCoroutine(rotateCoroutine);
        if(moveCoroutine != null)  StopCoroutine(moveCoroutine);
    }

    private IEnumerator RotateCoroutine()
    {
        float endTime = Time.time + 5;

        while(Time.time < endTime)
        {
            transform.Rotate(new Vector3(60f * Time.deltaTime, 0f, 0f));
            yield return null;
        }

    }

    private IEnumerator MoveCoroutine()
    {
        float endTime = Time.time + 5;

        while(Time.time < endTime)
        {
            transform.Translate(new Vector3(0f, 1f * Time.deltaTime, 0f));
            yield return null;
        }
    }

    private IEnumerator MainCoroutine()
    {
        while(true)
        {
            moveCoroutine = StartCoroutine(MoveCoroutine());
            yield return moveCoroutine;

            rotateCoroutine = StartCoroutine(MoveCoroutine());
            yield return rotateCoroutine;
        }
    }
}
