using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIDeathState : State
{
    float timer = 0;

    public AIDeathState(StateAgent agent) : base(agent)
    {

    }

    public override void OnEnter()
    {
        agent.movement.Stop();
        agent.movement.Velocity = Vector3.zero;

        agent.animator?.SetTrigger("Death");
        timer = Time.time + 2;
    }

    public override void OnExit()
    {
        if(Time.time > timer)
        {
            GameObject.Destroy(agent.gameObject);
        }
    }

    public override void OnUpdate()
    {

    }
}
