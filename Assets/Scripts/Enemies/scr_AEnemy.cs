using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class AEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    protected List<AttackStrategy> attackStrats;
    [SerializeField]
    protected List<MovementStrategy> moveStrats;

    protected static List<IEnemyTarget> targets = new();
    protected static List<Waypoint> waypoints = new();

    protected virtual void OnEnable()
    {
        RefreshTargets();
    }
    
    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        foreach (var strat in attackStrats) { strat.Execute(targets.First()); }
        foreach (var strat in moveStrats) { strat.Execute(waypoints.First().gameObject.transform); }
    }

    public static void RefreshTargets()
    {
        //TODO: Cache, or do it static, or do something else. This would be inefficient with many enemies
        targets = FindObjectsByType<Target>(FindObjectsSortMode.None).OfType<IEnemyTarget>().ToList();
        waypoints = FindObjectsByType<Waypoint>(FindObjectsSortMode.None).ToList();
    }
    
    
}
