using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemappableInput : MonoBehaviour
{
    private PlayerMotor m_pm;

    //TODO: Exercise 1.3 - Declare instancevariables for the 5 commands
    private IInputCommand up_command;
    private IInputCommand down_command;
    private IInputCommand left_command;
    private IInputCommand right_command;
    private IInputCommand jump_command;

    List<int> controls=new List<int>();

    private void Awake()
    {
        m_pm = FindObjectOfType<PlayerMotor>();
        //TODO: Exercise 1.4 - Assign concrete Commands to the instancevariables
        up_command=new MoveUp_Command();
        down_command=new MoveDown_Command();
        left_command=new MoveLeft_Command();
        right_command=new MoveRight_Command();
        jump_command=new Jump_Command();

        for(int i=0;i<5;i++)
        {
            controls.Add(i);
        }
    }

    void Update()
    {
        //TODO: Exercise 1.5 - Call the Execute-Method of each Command if the corresponding button was pressed.
        if(Input.GetKeyDown(KeyCode.W))
            up_command.Execute(m_pm);
        else if(Input.GetKeyDown(KeyCode.S))
            down_command.Execute(m_pm);
        else if(Input.GetKeyDown(KeyCode.A))
            left_command.Execute(m_pm);
        else if(Input.GetKeyDown(KeyCode.D))
            right_command.Execute(m_pm);
        else if(Input.GetKeyDown(KeyCode.Space))
            jump_command.Execute(m_pm);
    }


    public void RandomizeInput()
    {
        //TODO: Exercise 1.6 - Randomize inputmapping
        List<IInputCommand> commands=new List<IInputCommand>();
        commands.Add(up_command);
        commands.Add(down_command);
        commands.Add(left_command);
        commands.Add(right_command);
        commands.Add(jump_command);

        //Dictionary<int,string> controlName=new Dictionary<int, string>();
        //controlName.Add(0,"Up");
        //controlName.Add(1,"Down");
        //controlName.Add(2,"Left");
        //controlName.Add(3,"Right");
        //controlName.Add(4,"Jump");

        for(int i=0;i<commands.Count;i++)
        {
            IInputCommand temp=commands[i];
            int rndNum=Random.Range(0,commands.Count-1);
            commands[i]=commands[rndNum];
            commands[rndNum]=temp;
        }
        
        up_command=commands[0];
        down_command=commands[1];
        left_command=commands[2];
        right_command=commands[3];
        jump_command=commands[4];

        m_inputMappingText.text = "W: ???\nS: ???\nA: ???\nD: ???\nSpace: ???";
    }

    #region not relevant
    public UnityEngine.UI.Text m_inputMappingText;
    #endregion
}
