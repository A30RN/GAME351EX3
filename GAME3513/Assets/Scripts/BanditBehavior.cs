using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditBehavior : MonoBehaviour
{
    public GameObject bandit;

    Animator animController;
    Rigidbody rigidBody;


    // Start is called before the first frame update
    void Start()
    {
        animController = bandit.GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Death();
        }
    }

    void Death()
    {
        animController.SetBool("Die", true);
        Destroy(gameObject, 3);
    }
}
