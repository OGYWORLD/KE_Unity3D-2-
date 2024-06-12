using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerMove : MonoBehaviour
{
    public GameObject Wright = null;

    float xDirection = 0f;
    float zDirection = 0f;

    private float speed = 8f;
    private float detectRange = 1f;

    void Update()
    {
        GetInput();
        ShowInteract();
    }

    void GetInput()
    {
        xDirection = Input.GetAxis("Horizontal");
        zDirection = Input.GetAxis("Vertical");

        gameObject.transform.position += new Vector3(xDirection * speed * Time.deltaTime, 0f, zDirection * speed * Time.deltaTime);
    }

    public void ShowInteract()
    {
        if (Physics.Raycast(Wright.GetComponent<Transform>().transform.position, Wright.GetComponent<Transform>().transform.forward, out RaycastHit hit, detectRange))
        {
            print(hit.collider.name);
            if(hit.collider.CompareTag("Interactable"))
            {
                print("!");
                if(zDirection > 0f)
                {
                    zDirection = 0f;
                }
            }
        }
    }
}
