using System.Collections.Generic;
using UnityEngine;

public abstract class AEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    protected List<AStrategy> strategies;
    
    
    // Update is called once per frame
    void Update()
    {
        foreach (var strat in strategies) { strat.Execute(); }
    }
    
    
}
