using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Animator Porte;
    public string TriggerTag;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Ball")
        {
            Porte.SetTrigger(TriggerTag);
        }
    }
}
