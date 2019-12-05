using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform hoursTransform;
    public Transform minutesTransform;
    public Transform secondsTransform;
    const float degreesPerHour = 360 / 12;
    const float degreesPerMinuteAndSecond = 360 / 60;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var time = DateTime.Now;
        hoursTransform.localRotation =
            Quaternion.Euler(0f, time.Hour * degreesPerHour, 0f);
        minutesTransform.localRotation =
            Quaternion.Euler(0f, time.Minute * degreesPerMinuteAndSecond, 0f);
        secondsTransform.localRotation =
            Quaternion.Euler(0f, time.Second * degreesPerMinuteAndSecond, 0f);
    }

    void Awake()
    {
    }
}
