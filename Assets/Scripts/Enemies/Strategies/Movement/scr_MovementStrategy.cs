using UnityEngine;

public abstract class MovementStrategy : MonoBehaviour
{

    public abstract void Execute(Transform position);
    
}
