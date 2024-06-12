using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CChester : CInteraction
{
    // Animator
    public Animator chesterAnim = null;

    public override void ShowPreInteract()
    {
        dialog.SetActive(true);

        name.text = "����ȣ��";
        talk.color = Color.blue;
        talk.text = "(�� ���� F�� ������ �����?)";
    }

    public override void ShowInteract()
    {
        // Set Animation
        chesterAnim.SetBool("isOpen", true);

        // Set Text
        talk.text = "(���� ����...)";
    }

    public override void Init()
    {
        dialog.SetActive(false);
        chesterAnim.SetBool("isOpen", false);
    }
}

