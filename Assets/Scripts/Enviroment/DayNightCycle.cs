using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float time;
    public float fullDayLength;
    public float startTime = 0.4f;
    private float timeRate;
    public Vector3 noon;

    [Header("Sun")]
    public Light sun;
    public Gradient sunColor;
    public AnimationCurve sunIntensity;

    [Header("Moon")]
    public Light moon;
    public Gradient moonColor;
    public AnimationCurve moonIntensity;

    [Header("Other Lighting")]
    public AnimationCurve lightingIntensityMultiplier;
    public AnimationCurve reflectionsIntensityMultipler;

    public static DayNightCycle instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        timeRate = 1.0f / fullDayLength;
        time = startTime;
    }

    void Update()
    {
        // increment time
        time += timeRate * Time.deltaTime;

        if (time >= 1.0f)
            time = 0.0f;

        // light rotation
        sun.transform.eulerAngles = noon * ((time - 0.25f) * 4.0f);
        moon.transform.eulerAngles = noon * ((time - 0.75f) * 4.0f);

        // light intensity
        sun.intensity = sunIntensity.Evaluate(time);
        moon.intensity = moonIntensity.Evaluate(time);

        // change colors
        sun.color = sunColor.Evaluate(time);
        moon.color = moonColor.Evaluate(time);

        switch (sun.intensity)
        {
            // enable / disable the sun
            case 0 when sun.gameObject.activeInHierarchy:
                sun.gameObject.SetActive(false);
                break;
            case > 0 when !sun.gameObject.activeInHierarchy:
                sun.gameObject.SetActive(true);
                break;
        }

        switch (moon.intensity)
        {
            // enable / disable the moon
            case 0 when moon.gameObject.activeInHierarchy:
                moon.gameObject.SetActive(false);
                break;
            case > 0 when !moon.gameObject.activeInHierarchy:
                moon.gameObject.SetActive(true);
                break;
        }

        // lighting and reflections intensity
        RenderSettings.ambientIntensity = lightingIntensityMultiplier.Evaluate(time);
        RenderSettings.reflectionIntensity = reflectionsIntensityMultipler.Evaluate(time);
    }
}