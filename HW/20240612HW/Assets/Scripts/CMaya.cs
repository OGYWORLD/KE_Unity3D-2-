using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMaya : CInteraction
{
    public override void ShowPreInteract()
    {
        dialog.SetActive(true);

        name.text = "마요이";
        talk.text = "나루호도! 누가 날 이따구로 만든 거야! (대답 F)";
    }

    public override void ShowInteract()
    {
        name.text = "나루호도";
        talk.text = "나보단 너가 나은 거 같은데...";
    }

    public override void Init()
    {
        dialog.SetActive(false);
    }
}
