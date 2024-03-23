using UnityEngine;
using UnityEngine.AI;

public class AgenMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    private NavMeshAgent _agent;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _agent.speed = _speed;
    }

    void Update()
    {       
        SetAgentPosition();
    }
    
    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void SetAgentPosition()
    {
        _agent.SetDestination(new Vector3(_target.position.x, _target.position.y, transform.position.z));
    }
}
