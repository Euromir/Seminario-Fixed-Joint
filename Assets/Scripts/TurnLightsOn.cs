using UnityEngine;
using System.Collections;

public class TurnLightsOn : MonoBehaviour
{
    public float intensity = 1.0f;
    [Range(0.1f, 10.0f)]
    public float transitionDuration = 2.0f;
    private Light[] lights;
    private Coroutine fadeCoroutine;

    void Awake()
    {
        lights = GetComponentsInChildren<Light>(true);
    }

    void Start()
    {
        SetIntensity(0);
        StartGradualIncrease(transitionDuration);
    }

    public void StartGradualIncrease(float duration)
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(IncreaseIntensityGradually(duration));
    }

    public void SetIntensity(float value)
    {
        foreach (Light light in lights)
        {
            if (light != null)
                light.intensity = value;
        }
    }

    private IEnumerator IncreaseIntensityGradually(float duration)
    {
        float elapsedTime = 0;
        float initialIntensity = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / duration);
            float newIntensity = Mathf.Lerp(initialIntensity, intensity, progress);

            foreach (Light light in lights)
            {
                if (light != null)
                    light.intensity = newIntensity;
            }

            yield return null;
        }

        SetIntensity(intensity);
        fadeCoroutine = null;
    }
}
