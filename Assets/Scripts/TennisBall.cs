using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBall : MonoBehaviour
{
    [SerializeField] private PhysicMaterial leftSide;
    [SerializeField] private PhysicMaterial rightSide;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<TennisTable>(out TennisTable table))
        {
            if (other.collider.sharedMaterial == leftSide) table.OnBallTouched(TableSide.Left);
            else if (other.collider.sharedMaterial == rightSide) table.OnBallTouched(TableSide.Right);
            else Debug.LogError("Ball touched table, but no side assigned.");
        }
    }
}
