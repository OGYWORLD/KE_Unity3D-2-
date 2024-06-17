using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShowStore : MonoBehaviour
{
    public GameObject storeCanvas;
    public GameObject invenCanvas;

    private void OnTriggerEnter(Collider other)
    {
        storeCanvas.SetActive(true);
        invenCanvas.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        storeCanvas.SetActive(false);
    }
}
