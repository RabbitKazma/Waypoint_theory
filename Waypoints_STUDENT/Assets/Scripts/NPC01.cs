using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC01 : MonoBehaviour
{
    public Transform target = null;
    public float speed = 1.0f;
    const float speedInterpolationTime = .25f;
    const float directionInterpolationTime = 1.25f;

    Animator m_Animator = null;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.SetFloat("Speed", speed);
    }

    private void Update()
    {

        if(Vector3.Distance(target.position,transform.position) > 1f)
        {
            m_Animator.SetFloat("Speed", speed, speedInterpolationTime, Time.deltaTime);

            Vector3 currentDir = m_Animator.rootRotation * Vector3.forward;

            Vector3 wantedDir = (target.position - m_Animator.rootPosition);

            wantedDir = wantedDir.normalized;

            Vector3 cross = Vector3.Cross(currentDir, wantedDir);

            m_Animator.SetFloat("Direction", cross.y * 1.0f, directionInterpolationTime, Time.deltaTime);


        }
        else
        {
            if(m_Animator.GetFloat("Speed") < 0.5f)
            {
                m_Animator.SetFloat("Speed", 0);
                transform.position = target.position;
            }
            else
            {
                m_Animator.SetFloat("Speed", 0f, speedInterpolationTime, Time.deltaTime);
            }


        }
    }
}
