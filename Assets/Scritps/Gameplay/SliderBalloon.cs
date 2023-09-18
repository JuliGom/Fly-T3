using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBalloon : MonoBehaviour
{
    Slider sliderBalloonDelay;

    // Start is called before the first frame update
    void Start()
    {
        sliderBalloonDelay = GameObject.Find("BalloonFuel").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        sliderBalloonDelay.value = GameObject.Find("Player").GetComponent<BalloonMovement>().balloonDelay;
    }
}
