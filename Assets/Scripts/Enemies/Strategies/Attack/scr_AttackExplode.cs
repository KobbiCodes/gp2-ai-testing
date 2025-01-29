using System;
using NUnit.Framework.Constraints;
using UnityEngine;

public class AttackExplode : AttackStrategy
{
    [SerializeField]
    protected float chargeUpRange = 3f;
    [SerializeField]
    protected float explosionRange = 6f;
    [SerializeField]
    protected Timer chargeUpTimer;
    [SerializeField]
    protected Timer windDownTimer;
    
    bool _isChargingExplosion = false;
    bool _isWindingDown = false;
    GameObject _target = null;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        chargeUpTimer.timerDone += Explode;
        windDownTimer.timerDone += EnableExplosion;

    }
    
    void OnDisable()
    {
        chargeUpTimer.timerDone -= Explode;
        windDownTimer.timerDone -= EnableExplosion;
        
    }
    
    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0.2f, 0.1f, 0.8f);
        Gizmos.DrawWireSphere(transform.position, explosionRange);
        Gizmos.color = new Color(1f, 0.6f, 0.1f, 0.8f);
        Gizmos.DrawWireSphere(transform.position, chargeUpRange);
    }

    // Update is called once per frame
    
    public override void Execute(AEnemy enemy)
    {
        //throw new System.NotImplementedException();

        if (_isWindingDown && _isChargingExplosion) return;

        var targetInRange = false;
        foreach (var target in AEnemy.Targets)
        {
            if (target.activeSelf && Vector3.Distance(transform.position, target.transform.position) <= chargeUpRange)
            {
                targetInRange = true;
            }
        }
        if (targetInRange)
        {
            ChargeUp();
        }


    }

    public void ChargeUp()
    {
        _isChargingExplosion = true;
        chargeUpTimer.Restart();
    }

    public void Explode()
    {
        //TODO: Boom.
        
        //TODO: Code for dealing damage here.
        
        _isChargingExplosion = false;
        _isWindingDown = true;
        windDownTimer.Restart();
    } 
    
    void GetClosestTarget(AEnemy enemy)
    {
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

    public void StartChargeUp()
    {
        _isChargingExplosion = true;
    }

    public void EnableExplosion()
    {
        _isWindingDown = false;
    }
    
}
