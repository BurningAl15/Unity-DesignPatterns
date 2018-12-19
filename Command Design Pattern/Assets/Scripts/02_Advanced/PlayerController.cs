using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for determining which action the motor should perform (=Invoker)
/// </summary>
public class PlayerController : MonoBehaviour
{
    public UnityEngine.UI.Button m_undoBtn;
    private PlayerMotor m_pm;//Motor is used to move the player
    [SerializeField]
    bool m_isExecutingCommand;//Determines, if a command is currently being executed. Only use the Property m_IsExecutingCommand!!!

    //TODO Exercise 2.3 - Implement Queue Command
    //History of commands
    private List<ICommand> m_commandList;
    //Determines the current executed command of the list
    private int m_curCommandIndex=0;

    private void Awake()
    {
        m_historyUI = FindObjectOfType<HistoryUI>();
        m_pm = GetComponent<PlayerMotor>();
        m_commandList=new List<ICommand>();
    }

    /// <summary>
    /// Enqueue a new command to be executed
    /// </summary>
    /// <param name="cmd"></param>
    public void EnqueueCommand(ICommand cmd)
    {
        //TODO Exercise 2.3 - Implement Queue Command
        m_historyUI.AddEntry(cmd.GetCommandName());
        m_commandList.Add(cmd);
        if(m_isExecutingCommand==false)
            ExecuteCommand(m_curCommandIndex);
    }

    /// <summary>
    /// Undo the last command
    /// </summary>
    public void UndoCommand()
    {
        //TODO Exercise 3.1 - 1.	Implement the Undo-Functionality
        
    }

    /// <summary>
    /// Executes the command (however the playercontroller doesn't care at all what the command actually does)
    /// </summary>
    /// <param name="commandIndex"></param>
    private void ExecuteCommand(int commandIndex)
    {
        //TODO Exercise 2.3 - Implement Queue Command
        m_pm.actionCompleted+=OnExecutionCompleted;
        m_commandList[commandIndex].Execute();
        m_isExecutingCommand=true;
    }

    /// <summary>
    /// Called automatically when the current command has finished its execution
    /// </summary>
    private void OnExecutionCompleted()
    {
        //TODO Exercise 2.3 - Implement Queue Command
        m_pm.actionCompleted-=OnExecutionCompleted;
        m_IsExecutingCommand=false;
        m_curCommandIndex++;
        
        if(m_commandList.Count>m_curCommandIndex)
            ExecuteCommand(m_curCommandIndex);
    }

    /// <summary>
    /// Called automatically when the current command was successfully undone
    /// </summary>
    private void OnUndoCompleted()
    {
        //TODO Exercise 3.1 - Implement the Undo-Functionality 
    }

    #region not relevant

    private HistoryUI m_historyUI;


    public PlayerMotor m_PlayerMotor
    {
        get { return m_pm; }
    }

    private bool m_IsExecutingCommand
    {
        get
        {
            return m_isExecutingCommand;
        }

        set
        {
            m_isExecutingCommand = value;
            m_undoBtn.interactable = !value;
        }
    }
    #endregion
}
