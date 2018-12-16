using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObstacle : Obstacle {

    protected override void Awake()
    {
        base.Awake();

        _curHp = obstacleStats._simpleObstacle._maxHP;
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
            renderers[i].material.color = obstacleStats._simpleObstacle._color;
    }
}
