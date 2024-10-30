using System.Collections;
using UnityEngine;

public class Money : MonoBehaviour
{
    public bool IsActive { private set; get; } = false;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _rotateOffset;
    private Vector2 _upPoint = Vector2.zero;
    private Vector2 _lowPoint = Vector2.zero;

    public void Init(Vector2 upPoint, Vector2 lowPoint)
    {
        _upPoint = upPoint;
        _lowPoint = lowPoint;
        gameObject.SetActive(false);
    }

    public void Enable(Vector3 startPosition)
    {
        transform.position = startPosition;
        transform.eulerAngles = Vector3.forward * Random.Range(-_rotateOffset, _rotateOffset);
        IsActive = true;
        ChangeStateActiveObject();
        StartCoroutine(Animation());
    }

    public void Disable() 
    {
        IsActive = false;
        ChangeStateActiveObject();
    }

    private void ChangeStateActiveObject()
    {
        gameObject.SetActive(IsActive);
    }

    private IEnumerator Animation()
    {
        yield return Movement(_upPoint);
        yield return Movement(_lowPoint);
        Disable();
    }

    private IEnumerator Movement(Vector3 target)
    {
        var position = transform.position;
        while(position.y != target.y)
        {
            position.y = Mathf.MoveTowards(position.y, target.y, _speedMove * Time.deltaTime);
            transform.position = position;
            yield return null;
        }
    }
}
