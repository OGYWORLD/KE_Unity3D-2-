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

        name.text = "나루호도";
        talk.color = Color.blue;
        talk.text = "(이 상자 F를 눌러서 열어볼까?)";
    }

    public override void ShowInteract()
    {
        // Set Animation
        chesterAnim.SetBool("isOpen", true);

        // Set Text
        talk.text = "(별거 없네...)";
    }

    public override void Init()
    {
        dialog.SetActive(false);
        chesterAnim.SetBool("isOpen", false);
    }
}

