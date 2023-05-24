using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private float timer;

    private float currentTime;
    private AudioSource _audio;
    public bool Tick;

    private void Start()
    {
        image = GetComponent<Image>();
        currentTime = timer;
        _audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        Tick = false;
        currentTime -= Time.deltaTime;
        image.fillAmount = currentTime / timer;

        if (image.fillAmount == 0)
        {
            Tick = true;
            currentTime = timer;
            _audio.Play();
        }
    }
}
