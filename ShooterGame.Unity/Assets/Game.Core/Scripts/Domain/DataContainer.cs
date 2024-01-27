public class DataContainer
{
    public IMouseAxesInputService MouseAxesInputService { get; private set; }
    public ICameraService CameraService { get; private set; }
    public IBallService BallService { get; private set; }
    public IGunService GunService { get; private set; }

    public DataContainer(IMouseAxesInputService mouseAxesInputService, ICameraService cameraService, IBallService ballService, IGunService gunService)
    {
        MouseAxesInputService = mouseAxesInputService;
        CameraService = cameraService;
        BallService = ballService;
        GunService = gunService;
    }
}
