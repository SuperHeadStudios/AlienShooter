using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform m_Target;
    [SerializeField] private NavMeshAgent m_Agent;
    void Start()
    {
        
    }
    
    void Update()
    {
        m_Agent.SetDestination(m_Target.position);
    }
}
