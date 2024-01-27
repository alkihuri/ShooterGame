using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallConrtoller : MonoBehaviour
{

    IBallService ballService;

    Rigidbody rigidbody;    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    public void Innit(IBallService ballService)
    {
        this.ballService = ballService; 
    }
    // Update is called once per frame
    void FixedUpdate() => ballService?.PhysicUpdate(rigidbody);
}
