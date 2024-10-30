using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PoolMoney
{
    public Money[] _moneys { private set; get; } = new Money[POOL_SIZE];

    private static PoolMoney _instance;
    private const string NAME_PREFAB = "Money";
    private const int POOL_SIZE = 100;


    public PoolMoney(PlayerView view)
    {
        _instance = this;

        var prefab = Resources.Load(NAME_PREFAB).GetComponent<Money>();
        var poolParent = new GameObject("pool " + NAME_PREFAB);

        var camera = Camera.main;
        var hieghtPoint = view.GetPointLevel();
        var lowPoint = camera.transform.position - (Vector3.up * camera.orthographicSize);

        for (int i = 0; i < POOL_SIZE; i++)
        {
            _moneys[i] = Object.Instantiate(prefab, poolParent.transform);
            _moneys[i].Init(hieghtPoint, lowPoint);
        }
    }

    public static void ActiveMoney(Vector3 startPoint)
    {
        _instance.Activate(startPoint);
    }

    private void Activate(Vector2 startPoint)
    {
        var searth = _moneys.FirstOrDefault(p => p.IsActive == false);
        if(searth != null)
        {
            searth.Enable(startPoint);
        }
        else
        {
            throw new System.Exception($"{searth} is null");
        }
    }
}
