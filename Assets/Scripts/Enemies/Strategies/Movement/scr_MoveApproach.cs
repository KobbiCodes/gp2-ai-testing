using UnityEngine;

public class MoveApproach : MovementStrategy
{

    [SerializeField] protected GameObject moveTarget;
    
    [SerializeField] protected float speed = 1f;
    [SerializeField] protected float accelaration = 0.05f;
    
    [SerializeField] protected float turnSpeed = 20f;
    [SerializeField] protected float turnAcceleration = 4f;
    
    [SerializeField] protected float stopWhenWithin = 6.2f;
    
    
    protected void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.4f, 1f, 0.2f, 0.6f);
        Gizmos.DrawWireSphere(transform.position, stopWhenWithin);
    }
    
    public override void Execute(Transform position)
    {   
        throw new System.NotImplementedException();
    }
}
