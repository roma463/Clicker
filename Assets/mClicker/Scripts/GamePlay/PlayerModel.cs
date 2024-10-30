using System;
using UnityEngine;

public class PlayerModel
{
    public event Action<int> UpdateScore;
    public event Action<int, int, int> UpdateLevel;

    public int CurrentScore {private set; get; }= 0;
    public int CurrentLevelUpgrade {private set; get; } = 1;
    public int CurrentPriceUpgrade {private set; get; } = 10;
    public int AddCountOneClick { private set; get; } = 1;

    private Camera _camera;

    public void Init()
    {
        UpdateLevel(CurrentLevelUpgrade, CurrentPriceUpgrade, AddCountOneClick);
        UpdateScore(CurrentScore);
        _camera = Camera.main;
    }

    public void AddScore()
    {
        CurrentScore += AddCountOneClick;
        UpdateScore?.Invoke(CurrentScore);
        CanClickButtonUpgrade();

        var positionMouseInWorld = _camera.ScreenToWorldPoint(Input.mousePosition);
        PoolMoney.ActiveMoney(positionMouseInWorld);
    }

    private bool CanClickButtonUpgrade()
    {
        return CurrentScore >= CurrentLevelUpgrade;
    }

    public void UpLevelUpgrade()
    {
        if (CurrentScore < CurrentPriceUpgrade)
            throw new Exception("Текущий счет меньше значение за которое можно купить улучшение");

        CurrentScore -= CurrentPriceUpgrade;
        CurrentPriceUpgrade += CurrentPriceUpgrade / 2;
        CurrentLevelUpgrade++;
        AddCountOneClick++;

        UpdateScore?.Invoke(CurrentScore);
        UpdateLevel(CurrentLevelUpgrade, CurrentPriceUpgrade, AddCountOneClick);
    }
}
