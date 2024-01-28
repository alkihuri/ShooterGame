using Unity.VisualScripting;

public class Bootstrap
{
    public DataContainer Data { get; private set; }

    public Bootstrap()
    {
        var mouseAxesInputService = new WindowsMouseInputService();
        var cameraService = new CameraService();
        var ballService = new BallService();
        var gunService = new GunService();
        var gateService = new GateService();


        gunService.Innit(mouseAxesInputService, cameraService);
        ballService.Innit(mouseAxesInputService, cameraService);


        Data = new DataContainer(mouseAxesInputService, cameraService, ballService, gunService, gateService);
    }
}
