using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a Scriptableobject which is implemented using the Singleton - Designpattern
[CreateAssetMenu(fileName = "defaultGamePrefs", menuName = "GamePreferences")]
public class GamePreferences : ScriptableObject
{
    private static GamePreferences _myInstance;
    public static GamePreferences _MyInstance
    {
        get
        {
            if (_myInstance == null)
                _myInstance = Resources.Load<GamePreferences>("GamePreferences");
            return _myInstance;
        }
    }

    [Tooltip("Speed at which the player starts (m/s)")]
    public float _startSpeed;//Actually not the player moves but all the other objects move.
    [Tooltip("How much faster the player gets each second (m/s)")]
    public float _speedAcceleration;
    [Tooltip("Time between ObstacleSpawns")]
    public float _obstacleSpawnCd;

}
