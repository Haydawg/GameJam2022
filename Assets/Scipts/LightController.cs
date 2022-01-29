using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private Light light;
    public float maxItensity = 1.6f;
    public float minItensity = 0.4f;
    private bool brighter;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        StartCoroutine(LightFlicker(Random.Range(0.1f, 1)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator LightFlicker(float time)
    {
        yield return new WaitForSeconds(time);
        light.intensity = Random.Range(1, maxItensity);
        yield return new WaitForSeconds(time);
        light.intensity = Random.Range(maxItensity, 1);
        StartCoroutine(LightFlicker(Random.Range(0.1f, 1)));

    }
}
