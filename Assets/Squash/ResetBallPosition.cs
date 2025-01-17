using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBallPosition : MonoBehaviour
{
    private Vector3 initialPosition = new Vector3(-2.45f, 0.111f, -0.05f);

    [SerializeField] private string outWall = "Out";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(outWall))
        {
            transform.position = initialPosition;
        }
    }
}
