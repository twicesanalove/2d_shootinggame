using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class CommonSpaceship : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;

    public float shotDelay;

    public GameObject bullet;

    public GameObject explosion;

    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

    public void Move(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    public void Shot(Transform origin)
    {
        Instantiate(bullet, origin.position, origin.rotation);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
