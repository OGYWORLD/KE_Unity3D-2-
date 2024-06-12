using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPlayerMove : MonoBehaviour
{
    float xDirection = 0f;
    float zDirection = 0f;

    private float speed = 8f;
    private float detectRange = 1f;

    private bool isContact = false;
    private CInteraction itc = null;

    void Update()
    {
        GetInput();
        GetFInput();
    }

    void GetInput()
    {
        xDirection = Input.GetAxis("Horizontal");
        zDirection = Input.GetAxis("Vertical");

        BanPassForward();

        transform.position += transform.right * speed * Time.deltaTime * xDirection;
        transform.position += transform.forward * speed * Time.deltaTime * zDirection;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            itc = other.GetComponent<CInteraction>();
            if (itc != null)
            {
                isContact = true;
                itc.ShowPreInteract();
            }
        }
    }

    void GetFInput()
    {
        if (isContact)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                itc.ShowInteract();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        itc = other.GetComponent<CInteraction>();

        if(itc != null)
        {
            isContact = false;
            itc.Init();
        }
    }


    public void BanPassForward()
    {
        List<Vector3> pos = new List<Vector3>();

        pos.Add(transform.position + new Vector3(0f, 0.5f, 0f));
        pos.Add(transform.position + new Vector3(0f, 1f, 0f));

        foreach(Vector3 i in pos)
        {
            // check forward
            if (Physics.Raycast(i, transform.forward, out RaycastHit hit, detectRange))
            {
                if (hit.collider.CompareTag("Wall"))
                {
                    // Make zDirection Zero
                    if (zDirection > 0f)
                    {
                        zDirection = 0f;
                    }
                }
            }
        }
    }
}
