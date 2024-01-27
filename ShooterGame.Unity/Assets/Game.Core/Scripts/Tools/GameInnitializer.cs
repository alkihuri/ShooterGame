using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    void Awake()
    {
        BootstrapGame();
    }

    void BootstrapGame()
    {
        Bootstrap bootstrap = new Bootstrap();
        GameStateMachine gameStateMachine = gameObject.AddComponent<GameStateMachine>();
        gameStateMachine.Innit(bootstrap.Data);

        // Другие инициализации или запуск игры...
    }
}
