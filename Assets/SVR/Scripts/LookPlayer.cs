using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    public GameObject target;
    public bool restrictVerticalRotation = false;

    private void Start()
    {
        //target = FindObjectOfType<FirstPersonMovement>().gameObject;
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.transform.position;
            if (restrictVerticalRotation)
            {
                targetPosition.y = transform.position.y; // Keep the same y-axis position
            }

            transform.LookAt(targetPosition);
        }
    }
}
