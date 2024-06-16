using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMiles : CInteraction
{
    public override void ShowPreInteract()
    {
        dialog.SetActive(true);

        name.text = "�������";
        talk.text = "���� �� ���� �ΰ��� �̹����ΰ�. (��� F)";
    }

    public override void ShowInteract()
    {
        name.text = "����ȣ��";
        talk.text = "�Ӹ�ī���� ���� ��� �׳� ���� �־���...";
    }

    public override void Init()
    {
        dialog.SetActive(false);
    }
}
