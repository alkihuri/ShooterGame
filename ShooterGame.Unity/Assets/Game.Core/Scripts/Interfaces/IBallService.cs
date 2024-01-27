using UnityEngine;

public interface IBallService
{ 
    void Innit(IMouseAxesInputService mouseAxesInputService, ICameraService cameraService, GameObject view);

    void PhysicUpdate(Rigidbody rBody);
    void Hide();
    void Show();
    void Shoot(float power);
}