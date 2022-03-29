using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spider : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField]
    Transform target;
     [SerializeField, Range (0.1f,10f)]
     float moveSpeed = 2f;
     Animator anim;
      [SerializeField, Range(0.1f,7f)]
      float attackDistance = 2f;

    void Awake ()
    
    {
      agent = GetComponent<NavMeshAgent>();
      anim = GetComponent<Animator>();
      agent.destination = target.position;
    }

    void Start()
    {
    agent.speed = moveSpeed;
    agent.destination = target.position;

}

void Update ()
{
    if (!IsMoving)
    {
        agent.destination = transform.position;
    }
}

void LateUpdate()
{
 anim.SetFloat("move", MoveValue);
}
float MoveValue => Vector3.Distance(transform.position, target.position) > attackDistance ? 1f : 0f;
bool IsMoving => MoveValue >0f;

}