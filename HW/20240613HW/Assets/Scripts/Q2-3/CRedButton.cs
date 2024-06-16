using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRedButton : CQueueRandom
{
    public override void ColorIntoQueue()
    {
        color = Color.red;

        base.ColorIntoQueue();
    }
}
