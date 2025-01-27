using System;
using UnityEngine;

public class Target : MonoBehaviour, IEnemyTarget
{
    [SerializeField] 
    protected GameObject shell;
    [SerializeField] 
    protected GameObject core;

    public void Hit(Projectile projectile)
    {
        throw new System.NotImplementedException();
    }

    public void OnEnable()
    {
        AEnemy.Targets.Add(this.gameObject);
    }

    public void OnDisable()
    {
        AEnemy.Targets.Remove(this.gameObject);
    }
    
}
