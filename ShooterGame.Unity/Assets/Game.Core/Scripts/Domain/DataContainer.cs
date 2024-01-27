using System.Collections.Generic;
using UnityEngine;

public class DataContainer
{

    public IMouseAxesInputService MouseAxesInputService { get; private set; }
    public ICameraService CameraService { get; private set; }
    public IBallService BallService { get; private set; }
    public IGunService GunService { get; private set; }



    public List<IBallService> ServiceBalls = new List<IBallService>();
    public GameObject Gun { get; set; }
    public GameObject GameCamera { get; }

    public DataContainer(IMouseAxesInputService mouseAxesInputService, ICameraService cameraService, IBallService ballService, IGunService gunService)
    {
        MouseAxesInputService = mouseAxesInputService;
        CameraService = cameraService;
        BallService = ballService; // TODO: remove
        GunService = gunService;

        GameObject ballRoot = new GameObject("BallRoot");
        /// pool of objects 
        for (int i = 0; i < 15; i++)
        {

            var newBall = GameObject.Instantiate(Resources.Load<GameObject>("Ball"), ballRoot.transform);
            var newBallService = new BallService();
            newBall.GetComponent<BallConrtoller>().Innit(newBallService);   
            newBallService.Innit(MouseAxesInputService, CameraService, newBall);
            ServiceBalls.Add(newBallService);

            if (i > 0) ServiceBalls[i].Hide();
        }

        GunService.InnitBalls(ServiceBalls);
        Gun = GameObject.Instantiate(Resources.Load<GameObject>("Gun"));
        Gun.AddComponent<GunController>().Innit(MouseAxesInputService, GunService); 
        GameCamera = GameObject.Instantiate(Resources.Load<GameObject>("MainCamera"));
        CameraService.Innit(MouseAxesInputService, GameCamera);
        GameCamera.GetComponent<CameraController>().Innit(CameraService);
    }
}

