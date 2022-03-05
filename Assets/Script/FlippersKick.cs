using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippersKick : MonoBehaviour
{
    //Position
    public float Default = 0f;
    public float Kick;

    //Flippers "stats"
    public float Strenght = 10000;
    public float Damper = 150f;
    
    //Flipper Selection (Left or Right), no need to two different script
    public string selection;

    public HingeJoint hing;

    public AudioSource Sound;
    public bool played;

    void Start()
    {
        hing = GetComponent<HingeJoint>();
        hing.useSpring = true;
    }

    // Update is called once per frame
    void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = Strenght;
        spring.damper = Damper;
        
        if (Input.GetAxis(selection) == 1)
        {
            Debug.Log("Kick " + selection + " !");
            spring.targetPosition = Kick;
            if (!played)
            {
                Sound.pitch = 1 + Random.Range(-0.1f, 0.1f);
                Sound.Play();
                played = true;
            }
        }
        else
        {
            spring.targetPosition = Default;
            played = false;
        }
        hing.spring = spring;
        hing.useLimits = true;
    }
}
