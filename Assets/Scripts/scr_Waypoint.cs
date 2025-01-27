using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void OnEnable()
    {
        AEnemy.Waypoints.Add(this.gameObject);
    }

    public void OnDisable()
    {
        AEnemy.Waypoints.Remove(this.gameObject);
    }
}
