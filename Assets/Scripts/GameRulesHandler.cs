using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRulesHandler : MonoBehaviour
{
    [SerializeField] private GameObject table;

    private TennisGameState _gameState;

}

public enum TennisGameState
{
    Throwing,
    Playing
}