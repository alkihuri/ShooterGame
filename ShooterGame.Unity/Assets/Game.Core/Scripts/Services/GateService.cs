using UnityEngine;
using UnityEngine.Events;

public class GateService : IGateService
{
    public GameObject View { get; set; }

    public UnityEvent<IBallService> OnBallEnter = new UnityEvent<IBallService>();

    public void Innit(IMouseAxesInputService camera)
    {
        OnBallEnter.AddListener(IncresePlayerScore);
        OnBallEnter.AddListener(UIManager.CurrentSimulation.UpdateScore);
    }

    public void TakeBall(IBallService ballService) => OnBallEnter.Invoke(ballService);


    public void IncresePlayerScore(IBallService ballService)
    {
        var score = PlayerPrefs.GetInt("Score");
        score++;
        PlayerPrefs.SetInt("Score", score);
        ballService.Hide();
    }
}