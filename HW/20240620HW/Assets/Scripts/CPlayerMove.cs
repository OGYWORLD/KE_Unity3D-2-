using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerMove : MonoBehaviour
{
    private float xDirection;
    private float zDirection;

    private float speed = 40f;
    private float detectRange = 1f;

    public Transform rayFrontTrans;
    public Transform rayBackTrans;
    public Transform rayLeftTrans;
    public Transform rayRightTrans;

    private void Update()
    {
        Move();
    }

    void Move()
    {
        xDirection = Input.GetAxis("Horizontal");
        zDirection = Input.GetAxis("Vertical");

        DetectWall();

        transform.position += new Vector3(xDirection * speed * Time.deltaTime, 0f, zDirection * speed * Time.deltaTime);
    }

    void DetectWall()
    {
        // Front
        if (Physics.Raycast(rayFrontTrans.position, transform.forward, out RaycastHit hit, detectRange))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                if (zDirection > 0f)
                {
                    zDirection = 0f;
                }
            }
        }

        // Back
        if (Physics.Raycast(rayBackTrans.position, -transform.forward, out RaycastHit hit2, detectRange))
        {
            if (hit2.collider.CompareTag("Wall"))
            {
                if (zDirection < 0f)
                {
                    zDirection = 0f;
                }
            }
        }

        // Left
        if (Physics.Raycast(rayLeftTrans.position, -transform.right, out RaycastHit hit3, detectRange))
        {
            if (hit3.collider.CompareTag("Wall"))
            {
                if (xDirection < 0f)
                {
                    xDirection = 0f;
                }
            }
        }

        // Right
        if (Physics.Raycast(rayRightTrans.position, transform.right, out RaycastHit hit4, detectRange))
        {
            if (hit4.collider.CompareTag("Wall"))
            {
                if (xDirection > 0f)
                {
                    xDirection = 0f;
                }
            }
        }
    }
}
