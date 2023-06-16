using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

    public enum State
    {
        Automatic,
        Manual
    }

public class Fliper : MonoBehaviour
{
    [SerializeField] private float maxAngle;
    [SerializeField] private float minAngle;
    [SerializeField] private float hitSpring;
    [SerializeField] private float hitDamper;
    [SerializeField] private float timeToHit;

    [SerializeField] private bool isLeft;

    private JointSpring spring;
    private HingeJoint hinge;
    private float deltaTime;
    private bool IsUp = true;
    private State state;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        spring =  new JointSpring();
        deltaTime = timeToHit;

        hinge.useSpring = true;
        spring.spring = hitSpring;
        spring.damper = hitDamper;
    }

    void FixedUpdate()
    {
        switch (state)
        {
            case State.Automatic:
                MooveFliperAutomatic();
                break;
            case State.Manual:
                break;
        }
    }

    private void MooveFliperAutomatic()
    {
        deltaTime -= Time.deltaTime;
        if (deltaTime < 0)
        {
            if (IsUp)
            {
                if (!isLeft)
                {
                    spring.targetPosition = maxAngle;
                }
                else
                {
                    spring.targetPosition = -maxAngle;
                }
                IsUp = !IsUp;
            }
            else
            {
                spring.targetPosition = minAngle;
                IsUp = !IsUp;
            }
            deltaTime = timeToHit;
        }
        hinge.spring = spring;
    }


}
