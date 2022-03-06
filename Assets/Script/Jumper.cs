using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public string Tag;
    public float Bounce;
    public float direction;
    public float hauteur;

    public Material DefaultMaterial;
    public Material TouchedMaterial;
    public Renderer Renderer;
    public AudioSource Sound;
    public GameObject Particules;

    public bool touched;
    public float CD;

    private void Start()
    {
        Renderer = GetComponent<Renderer>();
        Renderer.enabled = true;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == Tag)
        {
            Rigidbody otherRB = other.GetComponent<Rigidbody>();
            Vector3 Jump = new Vector3(direction, 0f, hauteur);
            otherRB.AddForce(Jump * Bounce);
            touched = true;
            Sound.pitch = 0.8f + Random.Range(-0.1f, 0.1f);
            Sound.Play();
            Instantiate(Particules, transform.position, transform.rotation);
        }
    }
}
