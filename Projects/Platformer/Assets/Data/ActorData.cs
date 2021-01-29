using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorData : ScriptableObject
{
    [Header("Ground Detection")]
    [SerializeField]
    private LayerMask ground;
    [SerializeField]
    private float groundDetectionDepth;

    public LayerMask GroundLayers()
    {
        return ground;
    }

    public float GroundDetectionDepth()
    {
        return groundDetectionDepth;
    }
}
