using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFlare : MonoBehaviour
{

    private float mPauseDurationMin = 0.5f;
    private float mPauseDurationMax = 1.5f;
    private float mFlareDurationMin = 0.1f;
    private float mFlareDurationMax = 0.5f;
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
        Flame();
    }

    //火光抖动
    private void Flame()
    {
        float variation = Random.Range(-0.1f, 0.1f) + mLight.intensity;
        if (variation > 0.3f && variation < 3f)
        {
            mLight.intensity = variation;
        }
    }
    //开启光晕，并在随机时间后关闭
    private void EnableFlare()
    {
        mLight.flare = mFlare;
        Invoke("DisableFlare", Random.Range(mFlareDurationMin, mFlareDurationMax));
    }
    //关闭光晕，并在随机时间后开启
    private void DisableFlare()
    {
        mLight.flare = null;
        Invoke("EnableFlare", Random.Range(mPauseDurationMin, mPauseDurationMax));
    }
}
