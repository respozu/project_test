using System.Collections;
using UnityEngine;

public class TennisPlayer : MonoBehaviour
{
    [SerializeField] private GameObject directionPoint;

    [SerializeField] private Vector2 racketZRotationBorder;

    [SerializeField] private float rotationSpeed;

    [SerializeField] private float kickDistance;
    [SerializeField] private float kickCheckOffset;
    [SerializeField] [Range(0f, 1f)] private float kickSpeed;

    private bool _isKicked;
    private bool _canKick = true;

    private PlayerInput _input;

    private float _startZRot;

    private void Awake()
    {
        _input = new PlayerInput();

        _input.Player.Click.performed += context => TryStartKickCoroutine();

        _startZRot = transform.eulerAngles.z;
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void Update()
    {
        TransformRacket();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void TransformRacket()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));

        Vector3 newPositionWithoutX = new Vector3(transform.position.x, newPosition.y, newPosition.z);

        transform.position = newPositionWithoutX;

        transform.rotation = Quaternion.Euler
            (transform.eulerAngles.x,
            transform.eulerAngles.y,
            Mathf.Clamp(newPosition.z * rotationSpeed + _startZRot, racketZRotationBorder.x, racketZRotationBorder.y));
    }



    private void TryStartKickCoroutine()
    {
        if (!_canKick) return;
        _isKicked = true;
        StartCoroutine(Kick());
        _canKick = false;
    }

    private IEnumerator Kick()
    {
        Vector3 pos = transform.position;
        float goingX = pos.x - kickDistance;
        while (_isKicked)
        {
            pos.x = Mathf.Lerp(pos.x, goingX, kickSpeed);
            transform.position = pos;
            if (Mathf.Abs(transform.position.x - goingX) <= kickCheckOffset)
            {
                pos.x = goingX;
                transform.position = pos;
                _isKicked = false;
            }

            yield return new WaitForFixedUpdate();
        }
        bool kickEnds = true;
        float returningX = goingX + kickDistance;
        while (kickEnds)
        {
            pos.x = Mathf.Lerp(pos.x, returningX, kickSpeed);
            transform.position = pos;
            if (Mathf.Abs(transform.position.x - returningX) <= kickCheckOffset)
            {
                pos.x = returningX;
                transform.position = pos;
                kickEnds = false;
            }

            yield return new WaitForFixedUpdate();
        }
        _canKick = true;
        yield return null;
    }
}