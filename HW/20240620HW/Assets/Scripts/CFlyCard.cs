using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFlyCard : MonoBehaviour
{
    private float cardSpeed = 10f;

    private void Update()
    {
        Move();
    }

    void Move()
    {
        StartCoroutine(CardFly());
    }

    IEnumerator CardFly()
    {
        float sumTime = 0f;
        float totalTime = 3f;

        while(sumTime < totalTime)
        {
            transform.position += new Vector3(0f, 0f, cardSpeed * Time.deltaTime);

            sumTime += Time.deltaTime;

            yield return null;
        }

        gameObject.SetActive(false);

        yield break;
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if(other.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }
}
