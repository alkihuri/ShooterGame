using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallConrtoller : MonoBehaviour
{

    IBallService ballService;

    Rigidbody rigidbody;

    public IBallService BallService { get => ballService; set => ballService = value; }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    public void Innit(IBallService ballService)
    {
        this.BallService = ballService; 
    }
    // Update is called once per frame
    void FixedUpdate() => BallService?.PhysicUpdate(rigidbody);
}
