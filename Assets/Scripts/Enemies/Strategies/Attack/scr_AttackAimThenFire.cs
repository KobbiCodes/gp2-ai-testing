using System;
using UnityEngine;

public class AttackAimThenFire : AttackStrategy
{
    [SerializeField]
    protected GameObject cannonPivot;
    [SerializeField]
    protected GameObject cannon;
    
    [SerializeField]
    protected float cannonRotationSpeed;
    [SerializeField]
    protected GameObject projectile;
    
    [SerializeField]
    protected float startFireRate = 10f;
    [SerializeField]
    protected float stopFireRate = 15f;
    
    [SerializeField]
    protected Timer fireCooldown;

    void Start()
    {
        if (stopFireRate < startFireRate)
        {
            Debug.LogWarning("stopFireRate cannot be smaller than startFireRate. Defaulting stopFireRate to startFireRate + 5");
            stopFireRate = startFireRate + 5;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0.2f, 0.1f, 0.8f);
        Gizmos.DrawWireSphere(transform.position, startFireRate);
        Gizmos.color = new Color(1f, 0.6f, 0.1f, 0.8f);
        Gizmos.DrawWireSphere(transform.position, stopFireRate);
    }
    
    public override void Execute()
    {   
        //TODO: Implement
        throw new NotImplementedException();
    }

}
