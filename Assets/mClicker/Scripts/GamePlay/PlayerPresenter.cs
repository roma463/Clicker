
public class PlayerPresenter
{
    private readonly PlayerModel _playerModel;
    private readonly PlayerView _playerView;

    public PlayerPresenter(PlayerModel playerModel, PlayerView playerView)
    {
        _playerModel = playerModel;
        _playerView = playerView;

        // Подписка на события модели и привязка кнопок
        _playerView.AddScoreButton.onClick.AddListener(OnAddScoreButtonClicked);
        _playerView.UpgradeButton.onClick.AddListener(OnUpgradeButtonClicked);

        _playerModel.UpdateScore += OnScoreChanged;
        _playerModel.UpdateLevel += OnLevelUpgraded;
        SceneIndicator.DisabledScene += Dispose;
    }

    public void Init()
    {
        CheckActiveStateUpgrade();
    }

    private void OnAddScoreButtonClicked()
    {
        _playerModel.AddScore();
        CheckActiveStateUpgrade();
    }

    private void OnUpgradeButtonClicked()
    {
        _playerModel.UpLevelUpgrade();
        CheckActiveStateUpgrade();
    }

    private void OnScoreChanged(int newScore)
    {
        _playerView.UpdateScore(newScore);
    }

    private void OnLevelUpgraded(int newLevel, int priceNewLevel, int scoreAddClick)
    {
        _playerView.Upgrade(priceNewLevel, newLevel, scoreAddClick);
    }

    private void CheckActiveStateUpgrade()
    {
        var state = _playerModel.CurrentScore >= _playerModel.CurrentPriceUpgrade;
        _playerView.SetActiveStateUpgradeButton(state);
    }

    // Метод для отписки от событий, если нужно
    public void Dispose()
    {
        _playerView.AddScoreButton.onClick.RemoveListener(OnAddScoreButtonClicked);
        _playerView.UpgradeButton.onClick.RemoveListener(OnUpgradeButtonClicked);

        _playerModel.UpdateScore -= OnScoreChanged;
        _playerModel.UpdateLevel -= OnLevelUpgraded;

        SceneIndicator.DisabledScene -= Dispose;
    }
}