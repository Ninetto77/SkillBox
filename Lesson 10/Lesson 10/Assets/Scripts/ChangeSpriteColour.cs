using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteColour : MonoBehaviour
{
    private SpriteRenderer sprite;
    private bool IsRed = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(3))
        {
            Debug.Log("Ball");
            sprite = GetComponent<SpriteRenderer>();
            if (IsRed)
            {
                Debug.Log("Ball is blue");
                sprite.color = Color.blue;
            }
            else
            {
                Debug.Log("Ball is red");
                sprite.color = Color.red;

            }
            IsRed = !IsRed;
        }
    }
}
