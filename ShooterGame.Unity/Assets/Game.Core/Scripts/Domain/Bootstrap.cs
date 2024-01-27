public class Bootstrap
{
    public DataContainer Data { get; private set; }

    public Bootstrap()
    {
        var mouseAxesInputService = new WindowsMouseInputController();
        var cameraService = new CameraController();
        var ballService = new BallController();
        var gunService = new GunController();

        Data = new DataContainer(mouseAxesInputService, cameraService, ballService, gunService);
    }
}
