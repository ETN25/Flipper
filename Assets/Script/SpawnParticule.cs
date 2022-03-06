using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticule : MonoBehaviour
{
    public GameObject Particule;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(Particule, new Vector3(11f, 0.5f, -11f), Quaternion.identity);
    }
}
