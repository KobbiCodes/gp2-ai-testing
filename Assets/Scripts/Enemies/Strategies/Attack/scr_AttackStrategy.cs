using System;
using UnityEngine;

public abstract class AttackStrategy : MonoBehaviour
{
    public abstract void Execute(IEnemyTarget target);

}
