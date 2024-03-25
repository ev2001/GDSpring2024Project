using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatureAIIdleState : CreatureAIState
{
    public CreatureAIIdleState(CreatureAI creatureAI) : base(creatureAI){

    }

    public override void UpdateState()
    {
        //don't need to do anything
        creatureAI.myCreature.Stop();
        //if enemy detects player, change to hug state
        if(creatureAI.GetTarget() != null) {
            creatureAI.ChangeState(creatureAI.hugState);
        }
    }

    public override void BeginState()
    {
        creatureAI.myCreature.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
