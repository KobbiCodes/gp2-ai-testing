using System;
using UnityEngine;
using UnityEngine.Serialization;

public class AttackAimThenFire : AttackStrategy
{
    [SerializeField]
    protected GameObject cannonPivot;
    [SerializeField]
    protected GameObject cannon;
    
    [SerializeField]
    protected float cannonRotationSpeed = 20f;
    [SerializeField]
    protected GameObject projectile;
    
    [FormerlySerializedAs("startFireRate")] [SerializeField]
    protected float startFireRange = 6f;
    [SerializeField]
    protected float stopFireRate = 9f;
    [SerializeField]
    protected Timer fireCooldown;

    bool _fireReady = true;


    void OnEnable()
    {
        fireCooldown.timerDone += EnableFire;
    }
    
    void OnDisable()
    {
        fireCooldown.timerDone -= EnableFire;
    }

    void Start()
    {
        if (stopFireRate < startFireRange)
        {
            Debug.LogWarning("stopFireRate cannot be smaller than startFireRate. Defaulting stopFireRate to startFireRate + 5");
            stopFireRate = startFireRange + 5;
        }

        _fireReady = true;
        
    }

    protected void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0.2f, 0.1f, 0.8f);
        Gizmos.DrawWireSphere(transform.position, startFireRange);
        Gizmos.color = new Color(1f, 0.6f, 0.1f, 0.8f);
        Gizmos.DrawWireSphere(transform.position, stopFireRate);
    }
    
    public override void Execute(IEnemyTarget target)
    {   
        //TODO: Implement
        throw new NotImplementedException();
    }

    void EnableFire()
    {
        _fireReady = true;
    }

}
