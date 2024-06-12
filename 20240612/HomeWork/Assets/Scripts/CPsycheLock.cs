using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPsycheLock : CInteraction
{
    public GameObject psycheLock = null;

    public override void ShowPreInteract()
    {
        dialog.SetActive(true);

        name.text = "����ȣ��";
        talk.color = Color.blue;
        talk.text = "(F�� ������ �߱��غ���?)";
    }

    public override void ShowInteract()
    {
        psycheLock.SetActive(false);

        name.text = "����";
        talk.color = Color.white;
        talk.text = "���ƾ� �¾ƿ�.. �׳� ���� �þ��...";
    }

    public override void Init()
    {
        dialog.SetActive(false);
        psycheLock.SetActive(true);
    }
}
