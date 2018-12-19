using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void Execute();
    string GetCommandName();
}

/// <summary>
/// Concrete Command to Attack.
/// </summary>
public class AttackCommand : ICommand
{
    public PlayerMotor m_pm;
    public AttackCommand(PlayerMotor pm)
    {
        m_pm = pm;
    }

    public void Execute()
    {
        m_pm.Attack();
    }

    public string GetCommandName()
    {
        return "Attack";
    }

    //TODO: Exercise 2.2 - Implement Commands for MoveUp, MoveDown, MoveRight, MoveLeft
}

public class MoveUpCommand : ICommand
{
    public PlayerMotor m_pm;
    public MoveUpCommand(PlayerMotor pm)
    {
        m_pm = pm;
    }

    public void Execute()
    {
        m_pm.MoveUp();
    }

    public string GetCommandName()
    {
        return "MoveUp";
    }
}

public class MoveDownCommand : ICommand
{
    public PlayerMotor m_pm;
    public MoveDownCommand(PlayerMotor pm)
    {
        m_pm = pm;
    }

    public void Execute()
    {
        m_pm.MoveDown();
    }

    public string GetCommandName()
    {
        return "MoveDown";
    }
}

public class MoveRightCommand : ICommand
{
    public PlayerMotor m_pm;
    public MoveRightCommand(PlayerMotor pm)
    {
        m_pm = pm;
    }

    public void Execute()
    {
        m_pm.MoveRight();
    }

    public string GetCommandName()
    {
        return "MoveRight";
    }
}

public class MoveLeftCommand : ICommand
{
    public PlayerMotor m_pm;
    public MoveLeftCommand(PlayerMotor pm)
    {
        m_pm = pm;
    }

    public void Execute()
    {
        m_pm.MoveLeft();
    }

    public string GetCommandName()
    {
        return "MoveLeft";
    }
}