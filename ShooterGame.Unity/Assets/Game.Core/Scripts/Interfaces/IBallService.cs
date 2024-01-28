using UnityEngine;

public interface IBallService
{
    void Innit(IMouseAxesInputService mouseAxesInputService, ICameraService cameraService, GameObject view, IGunService gun);

    void PhysicUpdate(Rigidbody rBody);
    void Hide();
    void Show();
    void Shoot(float power, Vector3 direction);
}
