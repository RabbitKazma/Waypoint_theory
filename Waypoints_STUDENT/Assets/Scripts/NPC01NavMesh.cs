using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC01NavMesh : MonoBehaviour
{
    public GameObject goToObject;

    private NavMeshAgent NavMeshAgent;
    Animator m_Animator = null;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        NavMeshAgent.destination = goToObject.transform.position * Time.deltaTime;
    }
}
