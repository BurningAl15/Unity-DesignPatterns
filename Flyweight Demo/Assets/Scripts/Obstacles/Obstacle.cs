using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IDamagable
{
    //Reference to ScriptableObject
    public ObstacleStats obstacleStats;

    //InstanceVariables
    protected int _curHp;
    protected Vector3 _startingPos;
    protected LevelManager _levelManager;

    protected virtual void Awake()
    {
        _startingPos = transform.position;
        _levelManager = FindObjectOfType<LevelManager>();
    }

    protected virtual void Update()
    {
        float targetZPos = transform.position.z - _levelManager.CurSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, 0, targetZPos);

        if (transform.position.z == -10)
            Die();
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
        if (pc != null)
        {
            pc.ReceiveDamage(10);
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void ReceiveDamage(int dmg)
    {
        CurHp -= dmg;
    }

    public int CurHp
    {
        get { return _curHp; }
        set
        {
            _curHp = value;
            _curHp = Mathf.Max(_curHp, 0);
            if (_curHp <= 0)
                Die();
        }
    }
}
