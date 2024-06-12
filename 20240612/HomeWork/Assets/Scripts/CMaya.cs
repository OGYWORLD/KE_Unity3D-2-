using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMaya : CInteraction
{
    public override void ShowPreInteract()
    {
        dialog.SetActive(true);

        name.text = "������";
        talk.text = "����ȣ��! ���� �� �̵����� ���� �ž�! (��� F)";
    }

    public override void ShowInteract()
    {
        name.text = "����ȣ��";
        talk.text = "������ �ʰ� ���� �� ������...";
    }

    public override void Init()
    {
        dialog.SetActive(false);
    }
}
