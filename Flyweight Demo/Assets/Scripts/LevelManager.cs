using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GamePreferences _gamePrefs;
    public GameObject _simpleObstacle;
    public GameObject _mediumObstacle;
    public GameObject _hardObstacle;

    private float _timeLastObstacleSpawned;
    private float _curSpeed;

    private void Awake()
    {
        _timeLastObstacleSpawned = -999;
        _curSpeed = _gamePrefs._startSpeed;
    }

    void Update()
    {
        _curSpeed += _gamePrefs._speedAcceleration * Time.deltaTime;
        if (_timeLastObstacleSpawned + _gamePrefs._obstacleSpawnCd / (CurSpeed/20) < Time.time)
        {
            SpawnObstacle();
            _timeLastObstacleSpawned = Time.time;
        }
    }

    private void SpawnObstacle()
    {
        int rndNum = Random.Range(0, 3);
        GameObject goToSpawn;
        switch (rndNum)
        {
            case 0:
                goToSpawn = _simpleObstacle;
                break;
            case 1:
                goToSpawn = _mediumObstacle;
                break;
            case 2:
                goToSpawn = _hardObstacle;
                break;
            default:
                goToSpawn = _simpleObstacle;
                break;
        }

        float xPos = Random.Range(-5f, 5f);

        Instantiate(goToSpawn, new Vector3(xPos, 0, 30 + CurSpeed), goToSpawn.transform.rotation);
    }

    public float CurSpeed { get { return _curSpeed; } }
}
