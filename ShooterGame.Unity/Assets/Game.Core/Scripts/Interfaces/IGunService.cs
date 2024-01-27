using System.Collections.Generic;
using UnityEngine;

public interface IGunService
{
    public List<IBallService> Balls { get; set; }
    public void Shoot(float power);
    public void Innit(IMouseAxesInputService imouseservice, ICameraService cameraservice);
    void InnitBalls(List<IBallService> balls);
    public void Update(Transform transform);
}