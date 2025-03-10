using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject explosionEffect;
    public GameObject debrisPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Explode();
        }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Instantiate(debrisPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
