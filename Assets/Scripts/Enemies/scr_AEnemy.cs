using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class AEnemy : MonoBehaviour
{
#region Static
    protected static List<GameObject> targets = new();
    protected static List<GameObject> waypoints = new();

    public static List<GameObject> Targets { get => targets; }
    public static List<GameObject> Waypoints { get => waypoints; }
    
    
#endregion
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    protected List<AttackStrategy> attackStrats;
    [SerializeField]
    protected List<MovementStrategy> moveStrats;
    
    protected virtual void OnEnable()
    {
        
    }
    
    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        foreach (var strat in attackStrats) { strat.Execute(this); }
        foreach (var strat in moveStrats) { strat.Execute(this); }
    }
    
    
    /*
    public static void RefreshTargets()
    {
        targets = FindObjectsByType<Target>(FindObjectsSortMode.None).OfType<IEnemyTarget>().ToList();
        waypoints = FindObjectsByType<Waypoint>(FindObjectsSortMode.None).ToList();
    }
    */
    
}
