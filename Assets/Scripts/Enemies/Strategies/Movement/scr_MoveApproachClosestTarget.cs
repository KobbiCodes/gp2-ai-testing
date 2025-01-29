using System;
using UnityEngine;

public class MoveApproach : MovementStrategy
{
    
    [SerializeField] protected float stopWhenWithin = 6.2f;
    
    GameObject _target = null;
    
    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0.4f, 1f, 0.2f, 0.6f);
        Gizmos.DrawWireSphere(transform.position, stopWhenWithin);
    }
    
    public override void Execute(AEnemy enemy)
    {   
        var targetIsValid = _target && _target.activeSelf;

        if (targetIsValid)
        {
            
            var distanceToTarget = Vector3.Distance(transform.position, _target.transform.position);

            if (distanceToTarget > enemy.PerceptionRadius) { _target = null; }
            else if (distanceToTarget > stopWhenWithin) //keep target but don't move
            {
                
                var directionToTarget = (_target.transform.position - transform.position).normalized;

                Vector3 moveTo = _target.transform.position - (directionToTarget * stopWhenWithin);
                //
                //Let's try it like that.
                
                Ray ray = new Ray(moveTo, Vector3.down);
                if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit))
                {
                    enemy.Agent.destination = hit.point;  
                }
            }
            else
            {
                //enemy.Agent.destination = transform.position;
            }
        }
        else
        {
            TargetClosest(enemy);
        }
    }

    public void TargetClosest(AEnemy enemy)
    {
        //Move towards closest target:
        var distanceToClosest = enemy.PerceptionRadius;
                
        foreach (var target in AEnemy.Targets)
        {
            var distance = Vector3.Distance(target.transform.position, enemy.transform.position);
            if (distance < distanceToClosest)
            {
                //TODO: Check visibility?
                distanceToClosest = distance;
                _target = target;
            }
        } 

    }

    public void MoveTowardsTarget()
    {
        
    }
    
    
}
