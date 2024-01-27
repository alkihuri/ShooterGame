using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallConrtoller : MonoBehaviour
{

    IBallService ballService; 

    public BallConrtoller(IBallService ballService)
    {
        this.ballService = ballService;
        ballService.Innit(); 
    }
    // Update is called once per frame
    void Update() =>  ballService?.PhysicUpdate(); 
}
