using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

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
    [SerializeField]
    protected float projectileSpeed = 4f;
    
    [FormerlySerializedAs("startFireRate")] [SerializeField]
    protected float startFireRange = 6f;
    [SerializeField]
    protected float stopFireRate = 9f;
    [SerializeField]
    protected Timer fireCooldown;

    bool _fireReady = false;
    private bool _targetInFireRange = false;
    GameObject _target = null;


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

        _fireReady = false;
        
    }

    protected void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0.2f, 0.1f, 0.8f);
        Gizmos.DrawWireSphere(transform.position, startFireRange);
        Gizmos.color = new Color(1f, 0.6f, 0.1f, 0.8f);
        Gizmos.DrawWireSphere(transform.position, stopFireRate);
    }
    
    public override void Execute(AEnemy enemy)
    {
        var targetIsValid = _target && _target.activeSelf;
        

        if (targetIsValid)
        {
            var distanceToTarget = Vector3.Distance(transform.position, _target.transform.position);
            //TODO: Refactor this out of being spaghetti ala marinara
            if (_targetInFireRange)
            {
                if (distanceToTarget > stopFireRate)
                {
                    _targetInFireRange = false;
                }
                else
                {
                    Aim(enemy);
                    if (_fireReady) Shoot(enemy);
                }
            }
            else
            {
                if (distanceToTarget < startFireRange)
                {
                    _targetInFireRange = true;
                    EnterFireCooldown();
                }
            }

        }
        else { GetClosestTarget(enemy); }
        
    }

    void EnableFire()
    {
        _fireReady = true;
    }

    void GetClosestTarget(AEnemy enemy)
    {
        var distanceToClosest = 999f;
                
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

    void Aim(AEnemy enemy)
    {
        //TODO: Do this:
        //Step 1: Figure out how to do this :sob: 
    }

    void Shoot(AEnemy enemy)
    {
        //TODO: This would benefit from projectile pooling.
        Projectile newProj = Instantiate(
            original: projectile, 
            cannon.transform.position,
            Quaternion.identity
        ).GetComponent<Projectile>();
        newProj.Speed = projectileSpeed;
        newProj.Direction = (_target.transform.position - cannon.transform.position).normalized;
        
        EnterFireCooldown();
    }

    void EnterFireCooldown()
    {
        _fireReady = false;
        fireCooldown.Restart();
    }

}
