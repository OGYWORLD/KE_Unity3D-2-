using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CChester : MonoBehaviour, IInteractable
{
    private float detectRange = 0.5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {

        }
    }

    public void ShowInteract()
    {
        throw new System.NotImplementedException();
    }
}
