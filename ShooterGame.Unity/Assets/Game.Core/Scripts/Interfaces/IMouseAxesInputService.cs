public interface IMouseAxesInputService
{
    bool GetFireButtonPressed();
    bool GetFireButtonStillPressed();
    bool GetFireButtonReleased();
    float GetMouseX();
    float GetMouseY();
}