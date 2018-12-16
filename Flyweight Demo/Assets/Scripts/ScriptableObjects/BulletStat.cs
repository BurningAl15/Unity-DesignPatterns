using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "defaultBullet",menuName="BulletStat")]
public class BulletStat : ScriptableObject {
    public float _speed;
    public int _dmg;
    public Bullet.BulletType _bulletType;

    //public int _bulletSpeed = 8;
    //public int _bulletDmg = 1;
    //public Bullet.BulletType _bulletType = Bullet.BulletType.Friendly;
}
