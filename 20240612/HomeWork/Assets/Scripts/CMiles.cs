using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMiles : CInteraction
{
    public override void ShowPreInteract()
    {
        dialog.SetActive(true);

        name.text = "미츠루기";
        talk.text = "나는 왜 얼굴이 인게임 이미지인가. (대답 F)";
    }

    public override void ShowInteract()
    {
        name.text = "나루호도";
        talk.text = "머리카락이 답이 없어서 그냥 사진 넣었대...";
    }

    public override void Init()
    {
        dialog.SetActive(false);
    }
}
