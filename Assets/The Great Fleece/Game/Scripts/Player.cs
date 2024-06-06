using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    private NavMeshAgent _agent;
    private Animator _animator;
    private Vector3 _target;
    public GameObject coinPrefab;
    public AudioClip coinSound;
    private bool _hasTossedCoin = false;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CoinToss();
    }

    void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                _agent.destination = hitInfo.point;
                _animator.SetBool("Walk", true);
                _target = hitInfo.point;
            }
        }

        float distance = Vector3.Distance(transform.position, _target);

        if (distance < 3.0f)
        {
            _animator.SetBool("Walk", false);
        }
    }

    void CoinToss()
    {
        if (Input.GetMouseButtonDown(1) && _hasTossedCoin == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Instantiate(coinPrefab, hitInfo.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(coinSound, transform.position);
                _hasTossedCoin = true;
                GuardsToCoin(hitInfo.point);
                _animator.SetTrigger("Throw");
            }
        }
    }

    void GuardsToCoin(Vector3 coinPos)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
        foreach(var guard in guards)
        {
            NavMeshAgent currentAgent = guard.GetComponent<NavMeshAgent>();
            GuardAI currentGuard = guard.GetComponent<GuardAI>();
            Animator guardAnim = guard.GetComponent<Animator>();

            currentGuard.coinToss = true;
            currentAgent.SetDestination(coinPos);
            guardAnim.SetBool("Walk", true);
            currentGuard.coinPos = coinPos;
        }
    }
}
