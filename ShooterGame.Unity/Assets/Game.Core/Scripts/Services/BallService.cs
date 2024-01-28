using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallService : IBallService
{
    public IGunService Gun;

    public IMouseAxesInputService MouseAxesInputService;

    public ICameraService CameraService;

    public GameObject View { get; set; }

    public void Hide()
    {
      //  if (Gun.GetGunTransform() != null) // TODO: remove
        View.transform.position = Gun.GetGunTransform().position;
        View.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0); 
        View.SetActive(false);
    }

    public void Innit(IMouseAxesInputService mouseAxesInputService, ICameraService cameraService)
    {
        MouseAxesInputService = mouseAxesInputService;
        CameraService = cameraService;
    }

    public void Innit(IMouseAxesInputService mouseAxesInputService, ICameraService cameraService, GameObject view, IGunService gun)
    {
        Gun = gun;
        MouseAxesInputService = mouseAxesInputService;
        CameraService = cameraService;
        View = view;
    }

    public void PhysicUpdate(Rigidbody rBody)
    {
        Debug.DrawLine(rBody.position, rBody.position + rBody.velocity, Color.red, 1);
    }

    public void Shoot(float power, Vector3 direction)
    {

       // if (Gun.GetGunTransform() != null) // TODO: remove
        View.transform.position = Gun.GetGunTransform().position; 
        View.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);   

        var force = Mathf.Pow(power, 10);
        force = Mathf.Clamp(force, 1, 50); 
        force = 50;

        Debug.DrawLine(View.transform.position, View.transform.position + direction * force, Color.green, 1);

        View.GetComponent<Rigidbody>().AddForce(direction * force, ForceMode.Impulse);
    }

    public void Show()
    {
        View.SetActive(true);
        View.GetComponent<Rigidbody>().isKinematic = false;
        View.transform.position = Gun.GetGunTransform().position;
    }
}
