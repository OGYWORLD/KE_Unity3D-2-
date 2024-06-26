using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFlyBullet : MonoBehaviour
{
    private float speed = 5f;

    private void Update()
    {
        Flying();
    }

    void Flying()
    {
        transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);
    }
}
