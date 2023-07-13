using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    };

    public Collider bola;
    public Material offMaterial;
    public Material onMaterial;

    private SwitchState state;
    private MeshRenderer meshRenderer;
    

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        Set(false);

        StartCoroutine(BlinkTimerStart(5));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == bola)
        {
            Toggle();
        }
    }


    private void Set(bool active)
    {
        if(active == true)
        {
            state = SwitchState.On;
            meshRenderer.GetComponent<Renderer>().material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            meshRenderer.GetComponent<Renderer>().material = offMaterial;
            StartCoroutine(BlinkTimerStart(5));
        }
        
    }

    private void Toggle()
    {
        if(state == SwitchState.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;

        for(int i = 0; i < times; i++)
        {
            meshRenderer.GetComponent<Renderer>().material = onMaterial;
            yield return new WaitForSeconds(0.5f);
             meshRenderer.GetComponent<Renderer>().material = offMaterial;
            yield return new WaitForSeconds(0.5f);

        }
        
        state = SwitchState.Off;

        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }

}
