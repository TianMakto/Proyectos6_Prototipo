using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleRope : MonoBehaviour
{
    [SerializeField] DistanceJoint2D ropeLogic;
    [SerializeField] LineRenderer ropeRenderer;

    public void BreakRope()
    {
        ropeLogic.enabled = false;
        ropeRenderer.enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
