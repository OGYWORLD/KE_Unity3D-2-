using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGreenButton : CQueueRandom
{
    public override void ColorIntoQueue()
    {
        color = Color.green;

        base.ColorIntoQueue();
    }
}
