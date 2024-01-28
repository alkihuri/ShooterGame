using System.Collections;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private IMouseAxesInputService mouseAxesInputService;
    private IGunService gunService;

    [SerializeField, Range(0, 10)] private float power = 0;
    [SerializeField] private bool isPressed = false;

    public float Power { get => power; set { power = value; UIManager.CurrentSimulation.UpdateGunPower(value); } }

    public void Innit(IMouseAxesInputService mouseAxesInputService, IGunService gunService)
    {
        this.mouseAxesInputService = mouseAxesInputService;
        this.gunService = gunService;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;   
    }

    private void Update()
    {
        gunService?.Update(transform);

        if (mouseAxesInputService.GetFireButtonPressed())
        {
            StopAllCoroutines();
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        Power = 0;
        isPressed = true;

        while (mouseAxesInputService.GetFireButtonStillPressed())
        {
            Power += Time.deltaTime;


            yield return new WaitForFixedUpdate();
        }

        isPressed = false;
        gunService?.Shoot(Power);

        Power = 0;
    }
}
