using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallParticule : MonoBehaviour
{
    public Rigidbody Ball;
    public GameObject Fast, Infire;
    public ParticleSystem FastP, InfireP;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Ball.velocity.magnitude > 30)
        {
            Infire.SetActive(true);
            Fast.SetActive(false);
        }
        else if (Ball.velocity.magnitude > 10)
        {
            Infire.SetActive(false);
            Fast.SetActive(true);
        }
        else
        {
            Infire.SetActive(false);
            Fast.SetActive(false);
        }
    }
}
