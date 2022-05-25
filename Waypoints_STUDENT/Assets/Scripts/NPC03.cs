using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NPC03 : MonoBehaviour
{
    public string WayPointTag;
    Transform[] m_Waypoints;

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
        m_Waypoints = GameObject.FindGameObjectsWithTag(WayPointTag).Select(go => go.transform).OrderBy(go => go.name).ToArray();
    }

    private void Update()
    {
        Transform target = m_Waypoints[m_WayPointIndex];
        if (Vector3.Distance(target.position, m_Animator.rootPosition) > stopDistance)
        {
            m_Animator.SetFloat("Speed", speed, speedInterpolationTime, Time.deltaTime);
            Vector3 currentDir = m_Animator.rootRotation * Vector3.forward;
            Vector3 wantedDir = target.position - m_Animator.rootPosition;
            wantedDir = wantedDir.normalized;
            Vector3 cross = Vector3.Cross(currentDir, wantedDir);
            m_Animator.SetFloat("Direction", cross.y * maxDirection, directionInterpolationTime, Time.deltaTime);
        }
        else
        {
            //m_WayPointIndex = (m_WayPointIndex + 1) % m_Waypoints.Length;
            if (m_WayPointIndex == m_Waypoints.Length - 1)
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
