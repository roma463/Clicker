using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [field: SerializeField] public Button AddScoreButton { private set; get; }
    [field: SerializeField] public Button UpgradeButton { private set; get; }

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private TextMeshProUGUI _levelUpgrade;
    [SerializeField] private TextMeshProUGUI _priceUpgrade;
    [SerializeField] private TextMeshProUGUI _addScoreByClick;


    public void UpdateScore(int score)
    {
        _currentScore.text = score.ToString();
    }

    public void Upgrade(int priseScore, int levelUpgrade, int addScoreByCkick)
    {
        _priceUpgrade.text = $"{priseScore}";
        _levelUpgrade.text = $"LV {levelUpgrade}";
        _addScoreByClick.text = $"+{addScoreByCkick}";
    }

    public void SetActiveStateUpgradeButton(bool state)
    {
        UpgradeButton.interactable = state;
    }

    public Vector2 GetPointLevel() => _levelUpgrade.transform.position;
}
