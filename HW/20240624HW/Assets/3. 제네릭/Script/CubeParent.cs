using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeParent : MonoBehaviour
{
    private Transform[] cubes;

    public Color[] colors;
    public int[] xPositions;
    public float[] scales;

    private void Awake()
    {
        cubes = new Transform[transform.childCount];
        for(int i = 0; i < cubes.Length; i++)
        {
            cubes[i] = transform.GetChild(i);
        }
    }

    private void Start()
    {
        for(int i = 0; i < cubes.Length; i++)
        {
            // Set Color
            cubes[i].GetComponent<Renderer>().material.color =
                colors[i];

            // Set X Position
            Vector3 @localPosition = cubes[i].localPosition;
            @localPosition.x = xPositions[i];
            cubes[i].localPosition = @localPosition;

            // Set Scale
            cubes[i].localScale = Vector3.one * scales[i];

        }
    }
}
