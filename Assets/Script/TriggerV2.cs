using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerV2 : MonoBehaviour
{
    public Animator Porte;
    public bool Bool;
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
            Porte.SetBool("Open", Bool);
        }
    }
}
