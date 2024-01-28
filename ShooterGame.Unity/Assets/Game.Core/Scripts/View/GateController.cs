using System.Collections;
using UnityEngine;
using DG.Tweening;

public class GateController : MonoBehaviour
{
    IGateService gateService;

    public void Innit(IGateService gateService)
    {
        this.gateService = gateService;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BallConrtoller>())
        {
            var ball = collision.gameObject.GetComponent<BallConrtoller>();
            var ballService = ball.BallService;

            gateService.TakeBall(ballService);
        }
    }

    private void Start()
    {
        StartCoroutine(RandomMovement());
    }


    IEnumerator RandomMovement()
    {
        var x = transform.position.x;
        // random movent by x axis
        while (true)
        {
            yield return new WaitForSeconds(1f);
            transform.DOMove(new Vector3(x, Random.Range(-5f, 5f), Random.Range(-5f, 5f)), 1);
        }
    }
}
