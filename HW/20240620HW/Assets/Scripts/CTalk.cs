using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CTalk : MonoBehaviour
{
    public Text talks;
    public GameObject talkCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Amy"))
        {
            talkCanvas.SetActive(true);
            talks.text = "¿À´Ãµµ ¾È³çÇÏ¼¼¿ä...";
        }
        else if(other.CompareTag("Boss"))
        {
            talkCanvas.SetActive(true);
            talks.text = "±×·¡ ¾È³ç Ä«µå´Â ±×¸¸ ³¯¸®·Å";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        talkCanvas.SetActive(false);
    }
}
