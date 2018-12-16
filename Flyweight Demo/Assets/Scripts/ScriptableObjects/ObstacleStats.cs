using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ObstacleStats")]
public class ObstacleStats : ScriptableObject{
    public SimpleObstacleStat _simpleObstacle;
    public MediumObstacleStat _mediumObstacle;
    public HardObstacleStat _hardObstacle;
}

[System.Serializable]
public class SimpleObstacleStat
{
    /// <summary>
    /// How far away from the starting position will the Object move
    /// </summary>
    public float _movementDistance;
    /// <summary>
    /// How fast will the Object move
    /// </summary>
    public float _movementSpeed;
    public int _maxHP;
    public Color _color;
}

[System.Serializable]
public class MediumObstacleStat
{
    /// <summary>
    /// How far away from the starting position will the Object move
    /// </summary>
    public float _movementDistance;
    /// <summary>
    /// How fast will the Object move
    /// </summary>
    public float _movementSpeed;
    public int _maxHP;
    public Color _color;
}

[System.Serializable]
public class HardObstacleStat
{
    [Tooltip("How far away from the starting position will the Object move")]
    public float _movementDistance;
    [Tooltip("How fast will the Object move")]
    public float _movementSpeed;
    public int _maxHP;
    public Color _color;
    [Tooltip("Cooldown of shooting a bullet")]
    public float _shootCD;
}
