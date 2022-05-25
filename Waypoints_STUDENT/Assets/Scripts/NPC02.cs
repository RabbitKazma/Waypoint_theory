using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC02 : MonoBehaviour
{
    public Transform[] Waypoints;
    public float speed = 0.0f;
    public float stopDistance;

    const float maxDirection = 1.0f;
    const float directionInterpolationTime = .5f;
    const float speedInterpolationTime = 0.25f;

    int m_WayPointIndex = 0;

    Animator m_Animator = null;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Transform target = Waypoints[m_WayPointIndex];
        if(Vector3.Distance(target.position, m_Animator.rootPosition) > stopDistance)
        {
            m_Animator.SetFloat("Speed", speed, speedInterpolationTime, Time.deltaTime);
            Vector3 currentDir = m_Animator.rootPosition * 1;
            Vector3 wantedDir = target.position - m_Animator.rootPosition;
            wantedDir = wantedDir.normalized;
            Vector3 cross = Vector3.Cross(currentDir, wantedDir);
            m_Animator.SetFloat("Direction", cross.y * maxDirection, directionInterpolationTime, Time.deltaTime);
        }
        else
        {
            if(m_WayPointIndex == Waypoints.Length - 1)
            {
                m_WayPointIndex = 0;
            }
            else
            {
                m_WayPointIndex++;
            }

        }
    }
}
