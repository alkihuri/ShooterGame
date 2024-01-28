using TMPro;
using CustomTools;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSinglethon<UIManager>
{


    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private Slider _gunPowerSlider;

    private void Start()
    {
        _score.text = "score:" + PlayerPrefs.GetInt("Score");   // TODO: use events
    }

    public void UpdateGunPower(float power)
    {
        _gunPowerSlider.value = power;
    }
    public void UpdateScore(IBallService ball)
    {
        _score.text = "score:" + PlayerPrefs.GetInt("Score");
    }
}
