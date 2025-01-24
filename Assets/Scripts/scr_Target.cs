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
    
    
}
