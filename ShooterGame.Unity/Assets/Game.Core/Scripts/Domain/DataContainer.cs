using System.Collections.Generic;
using UnityEngine;

public class DataContainer
{

    public IMouseAxesInputService MouseAxesInputService { get; private set; }
    public ICameraService CameraService { get; private set; }
    public IBallService BallService { get; private set; }
    public IGunService GunService { get; private set; }
    public IGateService GateService { get; private set; }



    public List<IBallService> ServiceBalls = new List<IBallService>();
    public GameObject Gun { get; set; }
    public GameObject GameCamera { get; }
    public GameObject Gate { get; }

    public DataContainer(IMouseAxesInputService mouseAxesInputService, ICameraService cameraService, IBallService ballService, IGunService gunService, IGateService gateService)
    {
        MouseAxesInputService = mouseAxesInputService;
        CameraService = cameraService;
        BallService = ballService; // TODO: remove
        GunService = gunService;
        GateService = gateService;
        Gun = GameObject.Instantiate(Resources.Load<GameObject>("Gun"));

        GunService.InnitBalls(ServiceBalls);
        GunService.SetGunTransform(Gun.transform);

        Gun.AddComponent<GunController>().Innit(MouseAxesInputService, GunService);
        GameCamera = GameObject.Instantiate(Resources.Load<GameObject>("MainCamera"));
        CameraService.Innit(MouseAxesInputService, GameCamera);
        GameCamera.GetComponent<CameraController>().Innit(CameraService);
        Gate = GameObject.Instantiate(Resources.Load<GameObject>("Gate"));
        Gate.GetComponent<GateController>().Innit(GateService);
        GameObject ballRoot = new GameObject("BallRoot");

        // ballRoot.transform.SetParent(Gun.transform, true);
        /// pool of objects 
        for (int i = 0; i < 15; i++)
        {

            var newBallService = new BallService();
            var newBall = GameObject.Instantiate(Resources.Load<GameObject>("Ball"), ballRoot.transform);
            newBallService.Innit(MouseAxesInputService, CameraService, newBall, GunService);
            newBall.GetComponent<BallConrtoller>().Innit(newBallService);
            ServiceBalls.Add(newBallService);
            ServiceBalls[i].Hide();
        }
         


    }
}

