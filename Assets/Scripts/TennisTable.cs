using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisTable : MonoBehaviour
{
    [SerializeField] private GameRulesHandler ruller;

    public void OnBallTouched(TableSide side)
    {
        Debug.Log(side);
    }
}

public enum TableSide
{
    Left,
    Right
}