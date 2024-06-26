using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerInput : MonoBehaviour
{
    private float speed = 10f;

    private void Update()
    {
        PlayerInput();
    }

    void PlayerInput()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");

        transform.position += new Vector3(xDirection * speed * Time.deltaTime, 0f, yDirection * speed * Time.deltaTime);
    }
}
