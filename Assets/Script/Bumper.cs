using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public string Tag;
    public float Bounce;

    public Material DefaultMaterial;
    public Material TouchedMaterial;
    public Renderer Renderer;
    public AudioSource Sound;

    public GameObject Particule;

    public bool touched;
    public float CD;

    private void Start()
    {
        Renderer = GetComponent<Renderer>();
        Renderer.enabled = true;
        Sound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (touched)
        {
            Renderer.sharedMaterial = TouchedMaterial;
            CD += 1f * Time.deltaTime;
            if (CD > 0.1f)
            {
                touched = false;
                CD = 0f;
            }
        }
        else
        {
            Renderer.sharedMaterial = DefaultMaterial;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == Tag)
        {
            Instantiate(Particule, collision.transform.position, Quaternion.identity);
            Rigidbody otherRB = collision.rigidbody;
            otherRB.AddExplosionForce(Bounce, collision.contacts[0].point, 5);
            touched = true;
            Sound.pitch = 1 + Random.Range(-0.1f, 0.1f);
            Sound.Play();

            
        }
    }
}
