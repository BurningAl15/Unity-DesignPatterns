using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets up which commands are assigned to which inputs. (=Client)
/// </summary>
public class GameManager : MonoBehaviour
{

    PlayerController m_pc;

    private void Awake()
    {
        m_pc = FindObjectOfType<PlayerController>();
    }

    /// <summary>
    /// Automatically called, when a move-button is pressed
    /// </summary>
    /// <param name="direction"></param>
    public void OnMoveButtonPressed(string direction)
    {
        switch (direction)
        {
            case "up":
                //TODO: Exercise 2.4 - Enqueue the correct command for m_pc.
                m_pc.EnqueueCommand(new MoveUpCommand(m_pc.m_PlayerMotor));
                break;
            case "down":
                //TODO: Exercise 2.4 - Enqueue the correct command for m_pc.
                m_pc.EnqueueCommand(new MoveDownCommand(m_pc.m_PlayerMotor));
                break;
            case "right":
                //TODO: Exercise 2.4 - Enqueue the correct command for m_pc.
                m_pc.EnqueueCommand(new MoveRightCommand(m_pc.m_PlayerMotor));
                break;
            case "left":
                //TODO: Exercise 2.4 - Enqueue the correct command for m_pc.
                m_pc.EnqueueCommand(new MoveLeftCommand(m_pc.m_PlayerMotor));
                break;
        }
    }

    /// <summary>
    /// Automatically called, when the attack-button is pressed
    /// </summary>
    public void OnAttackButtonPressed()
    {
        //TODO: Exercise 2.4 - Enqueue the correct command for m_pc.
        m_pc.EnqueueCommand(new MoveUpCommand(m_pc.m_PlayerMotor));
    }

    public void OnUndoButtonPressed()
    {
        m_pc.UndoCommand();
    }
}
