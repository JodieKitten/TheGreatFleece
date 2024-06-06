using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{

    public List<Transform> wayPoints;
    private NavMeshAgent _agent;
    private Animator _animator;
    public bool coinToss = false;
    public Vector3 coinPos;

    private int _currentTarget;
    private bool _reverse = false;
    private bool _targetReached = false;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (wayPoints.Count > 0 && wayPoints[_currentTarget] != null && coinToss == false)
        {
            _agent.SetDestination(wayPoints[_currentTarget].position);
            
            float distance = Vector3.Distance(transform.position, wayPoints[_currentTarget].position);
            if(distance < 1 && (_currentTarget == 0 || _currentTarget == wayPoints.Count - 1))
            {
                _animator.SetBool("Walk", false);
            }
            else
            {
                _animator.SetBool("Walk", true);
            }

            if (distance < 0.5f && _targetReached == false)
            {
                _targetReached = true;
                StartCoroutine(Halt());
            }
        }
        else
        {
            float distance = Vector3.Distance(transform.position, coinPos);
            if(distance < 8)
            {
                _animator.SetBool("Walk", false);
            }
        }
    }

    IEnumerator Halt()
    {
        if(_currentTarget == 0 || _currentTarget == wayPoints.Count - 1)
        {
            yield return new WaitForSeconds(2.0f);
        }

        if(_reverse == true)
        {
            _currentTarget--;
            if (_currentTarget == 0)
            {
                _reverse = false;
                _currentTarget = 0;
            }
        }
        else if(_reverse == false)
        {
            _currentTarget++;
            if (_currentTarget == wayPoints.Count)
            {
                _reverse = true;
                _currentTarget--;
            }
        }
        _targetReached = false;
    }
}
