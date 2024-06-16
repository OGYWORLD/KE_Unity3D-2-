using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTest02 : CShowScreen
{
    public GameObject myCanvas = null;

    public override void SetCanvas()
    {
        base.SetCanvas();

        myCanvas.SetActive(true);
    }
}
