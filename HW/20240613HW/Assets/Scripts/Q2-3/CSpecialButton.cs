using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSpecialButton : CQueueRandom
{
    public override void ColorIntoQueue()
    {
        color = new Color(Random.Range(0f, 255f) / 255f, Random.Range(0f, 255f) / 255f, Random.Range(0f, 255f) / 255f);

        base.ColorIntoQueue();

    }
}
