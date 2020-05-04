using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private CharacterNavigationController navControl;
    void Start()
    {
        navControl = FindObjectOfType<CharacterNavigationController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        navControl.CollisionWarning = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        navControl.CollisionWarning = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        navControl.CollisionWarning = true;
    }
}
