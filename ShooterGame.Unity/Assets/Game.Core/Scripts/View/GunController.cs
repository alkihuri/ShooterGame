using System.Collections;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private IMouseAxesInputService mouseAxesInputService;
    private IGunService gunService;

    [SerializeField, Range(0, 10)] private float power = 0;
    [SerializeField] private bool isPressed = false;

    public void Innit(IMouseAxesInputService mouseAxesInputService, IGunService gunService)
    {
        this.mouseAxesInputService = mouseAxesInputService;
        this.gunService = gunService;
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
        power = 0;
        isPressed = true; 

        while (mouseAxesInputService.GetFireButtonStillPressed())
        {
            power += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        isPressed = false;
        gunService?.Shoot(power);
    }
}
