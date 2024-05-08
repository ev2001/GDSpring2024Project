using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CreatureAIHugState : CreatureAIState
{
    private float hugDistance = 0.5f;
    private float hugCooldown = 1.0f;
    private float lastHugTime = 0;

    public CreatureAIHugState(CreatureAI creatureAI) : base(creatureAI){}

    public override void BeginState()
    {
        //creatureAI.SetColor(Color.red);
    }

    public override void UpdateState()
    {
        Creature targetCreature = creatureAI.GetTarget();
        if(creatureAI.GetTarget() != null){
            creatureAI.myCreature.MoveCreatureToward(creatureAI.GetTarget().transform.position);
            CheckForHug(targetCreature.gameObject);
        }else{
            creatureAI.ChangeState(creatureAI.investigateState);
        }
    }

    //private void TryHugPlayer(GameObject target){
        //float hugDistance= 1f;
        //if(Vector3.Distance(creatureAI.transform.position, target.transform.position) < hugDistance)
        //{
            //target.GetComponent<Creature>().DecreaseLives(1);
        //}
    //}

    private void CheckForHug(GameObject target){
        if(Time.time - lastHugTime >= hugCooldown){
            //float distance = Vector3.Distance(creatureAI.transform.position, target.transform.position); 
            Vector3 direction = target.transform.position - creatureAI.transform.position;
            float distanceSquared = direction.sqrMagnitude;
            float hugDistanceSquared = hugDistance * hugDistance;
            if(distanceSquared <= hugDistanceSquared){
                lastHugTime = Time.time;
                Creature playerCreature = target.GetComponent<Creature>();
                if(playerCreature != null){
                    playerCreature.DecreaseLives(1);
                }    
            }
        }
    }
}
