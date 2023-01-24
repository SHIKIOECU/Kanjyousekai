using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : Singleton<GameState>
{
    public enum State
    {
        Play,
        Pause,
        Clear,
        Over
    }
    public State NowState;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void ChangeState(State value)
    {
        NowState = value;
    }

    

    
}
