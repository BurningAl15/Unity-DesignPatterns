using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardCodedInput : MonoBehaviour {

    private PlayerController m_pc;

    private void Awake()
    {
        m_pc = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        //Hardcoded
        if (Input.GetKeyDown(KeyCode.W))
            m_pc.m_PlayerMotor.MoveUp();
        else if (Input.GetKeyDown(KeyCode.S))
            m_pc.m_PlayerMotor.MoveDown();
        else if (Input.GetKeyDown(KeyCode.A))
            m_pc.m_PlayerMotor.MoveLeft();
        else if (Input.GetKeyDown(KeyCode.D))
            m_pc.m_PlayerMotor.MoveRight();
        else if (Input.GetKeyDown(KeyCode.Space))
            m_pc.m_PlayerMotor.Jump();
    }
}
