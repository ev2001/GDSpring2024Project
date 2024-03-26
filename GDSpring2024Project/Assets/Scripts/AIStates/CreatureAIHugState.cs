using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAIHugState : CreatureAIState
{

    public CreatureAIHugState(CreatureAI creatureAI) : base(creatureAI){}


    public override void BeginState()
    {
        //creatureAI.SetColor(Color.red);
    }

    public override void UpdateState()
    {
        if(creatureAI.GetTarget() != null){
            creatureAI.myCreature.MoveCreatureToward(creatureAI.GetTarget().transform.position);
        }else{
            creatureAI.ChangeState(creatureAI.investigateState);
        }
        // Collider2D playerCollider = Physics2D.OverlapCircle(creatureAI.transform.position, 1f);
        // if  (playerCollider != null && playerCollider.CompareTag("Player"))
        // {
        //     playerCollider.GetComponent<Creature>().DecreaseLives(1);
        // }

    }
}
