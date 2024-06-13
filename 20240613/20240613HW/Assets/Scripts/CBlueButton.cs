using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBlueButton : CQueueRandom
{
    public override void ColorIntoQueue()
    {
        color = Color.blue;

        base.ColorIntoQueue();
    }
}
