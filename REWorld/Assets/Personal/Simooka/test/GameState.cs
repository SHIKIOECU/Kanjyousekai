using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public enum State
    {
        Play,
        Pause,
        Clear,
        Over
    }
    public State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Play;
    }

    

    
}
