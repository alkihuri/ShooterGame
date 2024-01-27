using UnityEngine;

public class DataContainer
{

    public IMouseAxesInputService MouseAxesInputService { get; private set; }
    public ICameraService CameraService { get; private set; }
    public IBallService BallService { get; private set; }
    public IGunService GunService { get; private set; }


    public GameObject Ball { get; set; }
    public GameObject Gun { get; set; }

    public DataContainer(IMouseAxesInputService mouseAxesInputService, ICameraService cameraService, IBallService ballService, IGunService gunService)
    {
        MouseAxesInputService = mouseAxesInputService;
        CameraService = cameraService;
        BallService = ballService;
        GunService = gunService;


        Ball = GameObject.Instantiate(Resources.Load<GameObject>("Ball"));
        Gun = GameObject.Instantiate(Resources.Load<GameObject>("Gun"));
    }
}

