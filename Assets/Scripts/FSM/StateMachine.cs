using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private Dictionary<string, State> states = new Dictionary<string, State>();
    public State CurrentState { get; private set; }
    public void Update()
    {
        CurrentState?.OnUpdate();
    }

    public void AddState(string name, State state)
    {
        Debug.Assert(!states.ContainsKey(name), "State machine already contains state " + name);

        states[name] = state;
    }

    public void SetState(string name)
    {
        Debug.Assert(states.ContainsKey(name), "State machine already contains state " + name);

        State nextState = states[name];
        if (nextState == CurrentState) return;

        CurrentState?.OnExit();
        CurrentState = nextState;
        CurrentState.OnEnter();
    }
}
