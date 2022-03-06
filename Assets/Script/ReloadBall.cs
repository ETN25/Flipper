using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadBall : MonoBehaviour
{ 
    public Rigidbody Ball;
    public bool AllowStart = true;
    public float Strength;
    public float BaseStrengt = 1500;
    public AudioSource Sound;
    public AudioSource Explosion;
    public GameObject Particule;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(11f, 0.5f, -11f);
        Ball = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AllowStart && gameObject.transform.position.z < - 11f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Sound.Play();
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if (Strength <= 5)
                {
                    Strength += 1f * Time.deltaTime;
                }
                Sound.pitch = Strength / 2;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Instantiate(Particule, transform.position, new Quaternion(0f, 0f, 0f, 0f));
                Explosion.pitch = 1f - Strength / 10f;
                Strength = Strength * 500f + BaseStrengt;
                Vector3 Jump = new Vector3(0f, 0f, Strength);
                Ball.AddForce(Jump);
                Sound.Stop();
                Explosion.Play();
                Sound.pitch = 1f;
                Explosion.pitch = 1f;
                Strength = 0f;

            }
            
        }

        if (gameObject.transform.position.z > 3f)
        {
            AllowStart = false;
        }

        if (gameObject.transform.position.z < -20f)
        {
            transform.position = new Vector3(11f, 0.5f, -11f);
            Ball.velocity = new Vector3(0f, 0f, 0f);
            AllowStart = true;
            Strength = 0f;

        }
    }
}
