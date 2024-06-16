using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPsycheLock : CInteraction
{
    public GameObject psycheLock = null;

    public override void ShowPreInteract()
    {
        dialog.SetActive(true);

        name.text = "나루호도";
        talk.color = Color.blue;
        talk.text = "(F를 눌러서 추궁해볼까?)";
    }

    public override void ShowInteract()
    {
        psycheLock.SetActive(false);

        name.text = "증인";
        talk.color = Color.white;
        talk.text = "으아악 맞아요.. 그날 제가 봤어요...";
    }

    public override void Init()
    {
        dialog.SetActive(false);
        psycheLock.SetActive(true);
    }
}
