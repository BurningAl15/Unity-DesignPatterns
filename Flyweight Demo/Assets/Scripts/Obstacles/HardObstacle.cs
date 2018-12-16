using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardObstacle : Obstacle {
    [SerializeField]
    private float _lastTimeShot;

    //BulletStats
    //private int _bulletSpeed = 8;
    //private int _bulletDmg = 1;
    //private Bullet.BulletType _bulletType = Bullet.BulletType.Hostile;
    public BulletStat bullet;

    protected override void Awake()
    {
        base.Awake();
        _curHp = obstacleStats._hardObstacle._maxHP;
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
            renderers[i].material.color = obstacleStats._hardObstacle._color;
    }

    protected override void Update()
    {
        base.Update();
        float targetXPos = _startingPos.x + Mathf.Sin(Time.time * obstacleStats._hardObstacle._movementSpeed) * obstacleStats._hardObstacle._movementDistance;
        transform.position = new Vector3(targetXPos, 0, transform.position.z);

        if (_lastTimeShot + obstacleStats._hardObstacle._shootCD < Time.time)
        {
            Shoot();
            _lastTimeShot = Time.time;
        }
    }

    private void Shoot()
    {
        bullet._speed=_levelManager.CurSpeed + bullet._speed;
        Bullet.InstantiateBullet(transform.position + Vector3.up, transform.forward,bullet, bullet._bulletType);
    }

}
