using System;
using UnityEngine;
public class Timer : MonoBehaviour
{
    
    public delegate void OnTimerDone();
    public event OnTimerDone timerDone;
    
    //TODO: Setter and getter for these two.
    [SerializeField]
    protected float timerDuration = 5f;
    protected float currentTime = 0f; 
    
    
    
    bool _paused = true;

    void OnEnable()
    {
        _paused = true;
    }

    void FixedUpdate()
    {
        if (!_paused) currentTime += Time.fixedDeltaTime;
        if (currentTime >= timerDuration) TriggerTimer();
    }
    
    void TriggerTimer()
    {
       // currentTime -= timerDuration;
        timerDone?.Invoke();
        _paused = true;
        currentTime = 0f;
        
    }

    public void Start()
    {
        _paused = false;
    }
    
    public void Stop()
    {
        _paused = true;
    }


    public bool IsRunning()
    {
        return _paused;
    }

    public void Reset()
    {
        currentTime = 0f;
    }



}
