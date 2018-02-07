using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFlare : MonoBehaviour
{

    private float PauseDurationMin = 0.5f;
    private float PauseDurationMax = 1.5f;
    private float FlareDurationMin = 0.1f;
    private float FlareDurationMax = 0.5f;
    private Flare mFlare;
    private Light mLight;

    void Start()
    {
        mLight = GetComponent<Light>();
        mFlare = mLight.flare;
        DisableFlare();
    }

    private void Update()
    {
        float variation = Random.Range(-0.1f, 0.1f) + mLight.intensity;
        if (variation > 0.3f && variation <3f)
        {
            mLight.intensity = variation;
        }
    }

    private void EnableFlare()
    {
        mLight.flare = mFlare;
        Invoke("DisableFlare", Random.Range(FlareDurationMin, FlareDurationMax));
    }
    private void DisableFlare()
    {
        mLight.flare = null;
        Invoke("EnableFlare", Random.Range(PauseDurationMin, PauseDurationMax));
    }
}
