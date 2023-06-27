using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float speed;
        private Rigidbody body;

        private void Awake()
        {
            body = GetComponent<Rigidbody>();
        }

        public void MovePlayer(Vector3 move)
        {
            body.AddForce(move * speed, ForceMode.Force);
        }

#if UNITY_EDITOR
        [ContextMenu("Reset values")]
        public void ResetValues()
        {
            speed = 2f;
        }
#endif
    }
}

