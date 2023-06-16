using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Starter : MonoBehaviour
{
    [SerializeField] private float maxPower = 100;
    [SerializeField] private float powerStep = 5000;
    [SerializeField] private UnityEngine.UI.Slider powerSlider;
    [SerializeField] private GameObject Wall;
    private Rigidbody body;
    private float power;
    private float minPower = 0;
    private bool IsReady;


    private void Start()
    {     
        powerSlider.minValue = minPower; 
        powerSlider.maxValue = maxPower;
    }

    private void Update()
    {
        if (body != null)
        {
            IsReady = true;
            if (Input.GetKey(KeyCode.Space))
            {
                if (power <= maxPower)
                {
                    power += powerStep * Time.deltaTime;
                }
            }
            
            if(Input.GetKeyUp(KeyCode.Space))
            {
                body.AddForce(power * Vector3.forward, ForceMode.Impulse);
            }
        }
        else
        {
            IsReady = false;
            power = minPower;
        }

        powerSlider.gameObject.SetActive(IsReady);
        powerSlider.value = power;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer.Equals(3))
        {
            Wall.SetActive(false);
            body = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer.Equals(3))
        {
            Wall.SetActive(true);
            body = other.gameObject.GetComponent<Rigidbody>();
        }
    }

}
