
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private GameObject evenTail;
    [SerializeField] private GameObject oddTail;
    private const float stepsize = 0.5f;
    private const uint _tailMaxLen = 150;
    private Vector3 _direction;
    private float time;
    private SpriteRenderer Fliper;
    private Vector3 _headPos;
    private Vector3 _tailPos;
    private List<GameObject> _tail;


    private void OnEnable()
    {
        EatFood.instance += AddTail;
    }

    void Start()
    {
        _tail = new List<GameObject>();
        
        _direction = Vector3.zero;
        time = 0;
        Fliper = GetComponent<SpriteRenderer>();

    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        Debug.Log(_headPos + " " + _tailPos);
        if (time > 0.2)
        {
            _headPos = transform.position;
            _direction = GetDirection();
            transform.position += _direction;
            if(_tail.Count > 0) _tailPos = _tail[_tail.Count-1].transform.position;
            else _tailPos = _headPos;
            for (int i = _tail.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    _tail[i].transform.position = _headPos;
                }
                else
                {
                    _tail[i].transform.position = _tail[i - 1].transform.position;
                }
                    
             }
            
            time = 0;
        }
        
    }

    private Vector3 GetDirection()
    {
        Vector3 Result = Vector3.zero;
        if (Input.GetAxis("Horizontal") < 0)
        {
            
            Result = Vector3.left * stepsize;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            Result = Vector3.right * stepsize;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            Result = Vector3.down * stepsize;
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            Result = Vector3.up * stepsize;
        }

        if(_direction != -Result && Result != Vector3.zero)  return Result;
        return _direction;
    }
    private void AddTail()
    {
        if(_tail.Count<= _tailMaxLen)
        {
            GameObject NewTail;
            if (_tail.Count % 2 == 0) NewTail = evenTail;
            else NewTail = oddTail;
            _tail.Add (SpawnTail(NewTail)) ;
        }
        

    }

    private GameObject SpawnTail(GameObject TailObject)
    {
        return Instantiate(TailObject, _tailPos, Quaternion.identity);
    }

    private void OnDisable()
    {
        EatFood.instance -= AddTail;
    }
}
