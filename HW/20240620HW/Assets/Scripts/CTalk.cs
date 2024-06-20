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
            talks.text = "���õ� �ȳ��ϼ���...";
        }
        else if(other.CompareTag("Boss"))
        {
            talkCanvas.SetActive(true);
            talks.text = "�׷� �ȳ� ī��� �׸� ������";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        talkCanvas.SetActive(false);
    }
}
