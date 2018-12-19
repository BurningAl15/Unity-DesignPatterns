using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputCommand {
    void Execute(PlayerMotor pm);
}

public class MoveUp_Command:IInputCommand
{
    public void Execute(PlayerMotor pm)
    {
        pm.MoveUp();
    }
}

public class MoveDown_Command:IInputCommand
{
    public void Execute(PlayerMotor pm)
    {
        pm.MoveDown();
    }
}

public class MoveLeft_Command:IInputCommand
{
    public void Execute(PlayerMotor pm)
    {
        pm.MoveLeft();
    }
}

public class MoveRight_Command:IInputCommand
{
    public void Execute(PlayerMotor pm)
    {
        pm.MoveRight();
    }
}

public class Jump_Command:IInputCommand
{
    public void Execute(PlayerMotor pm)
    {
        pm.Jump();
    }
}