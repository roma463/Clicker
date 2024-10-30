using UnityEngine;

public class GameEntryPoint
{
    private static GameEntryPoint _instance;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void RunGame()
    {
        if( _instance == null )
            _instance = new GameEntryPoint();
    }

    public GameEntryPoint()
    {
        InitGame();
    }

    private void InitGame()
    {
        var view = Object.FindObjectOfType<PlayerView>();
        var model = new PlayerModel();
        var prefenter = new PlayerPresenter(model, view);
        prefenter.Init();
        model.Init();

        new GameObject("[Scene Indicator]").AddComponent<SceneIndicator>();
        new PoolMoney(view);
    }
}
