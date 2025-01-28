using UnityEngine;

public class MoveApproach : MovementStrategy
{
    
    [SerializeField] protected float stopWhenWithin = 6.2f;
    
    
    protected void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.4f, 1f, 0.2f, 0.6f);
        Gizmos.DrawWireSphere(transform.position, stopWhenWithin);
    }
    
    public override void Execute(AEnemy enemy)
    {   
       //Move towards closest target:
       //Step 1: Determine closest target.
       //Step 2: Take into account maximum approach
       //Step 3: Raycast into the navmesh.
       //Step 4: Profit.
    }
}
