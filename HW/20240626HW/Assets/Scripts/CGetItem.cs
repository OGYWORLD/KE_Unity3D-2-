using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGetItem : MonoBehaviour
{
    private CInven item;

    private void Start()
    {
        item = GetComponent<CInven>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HealItem"))
        {
            item.getItems.Add(0);
            other.gameObject.SetActive(false);
        }
    }
}
