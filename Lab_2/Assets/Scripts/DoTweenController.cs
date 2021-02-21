using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenController : MonoBehaviour
{
    [SerializeField]
    private Vector3 _targetLocation = new Vector3();
    private float _currentPos;
    private float _moveDuration = 1.0f;
    private Ease _moveEase = Ease.Linear;

    // Start is called before the first frame update
    void Start()
    {
        _currentPos = transform.position.x;
    }

    private void FixedUpdate()
    {
        if (transform.position.x == _currentPos)
        {
            StartCoroutine(MoveWithBothWays());
        }
    }

    private IEnumerator MoveWithBothWays()
    {
        float posX = transform.position.x;
        transform.DOMoveX(_targetLocation.x, _moveDuration).SetEase(_moveEase);
        yield return new WaitForSeconds(_moveDuration);
        transform.DOMoveX(posX, _moveDuration).SetEase(_moveEase);
    }
}
