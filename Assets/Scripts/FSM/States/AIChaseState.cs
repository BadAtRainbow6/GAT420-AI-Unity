using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIChaseState : State
{
    float initialSpeed;

    public AIChaseState(StateAgent agent) : base(agent)
    {
        AIStateTransition transition = new AIStateTransition(nameof(AIAttackState));
        transition.AddCondition(new BoolCondition(agent.enemySeen));
        transition.AddCondition(new FloatCondition(agent.enemyDistance, Condition.Predicate.LESS, 1));
        transitions.Add(transition);

        transition = new AIStateTransition(nameof(AIIdleState));
        transition.AddCondition(new BoolCondition(agent.enemySeen, false));
        transitions.Add(transition);
    }

    public override void OnEnter()
    {
        agent.movement.Resume();
        initialSpeed = agent.movement.maxSpeed;
        agent.movement.maxSpeed += 2;
    }

    public override void OnUpdate()
    {
        if(agent.enemySeen) agent.movement.Destination = agent.enemy.transform.position;
    }

    public override void OnExit()
    {
        agent.movement.maxSpeed = initialSpeed;
    }
}
