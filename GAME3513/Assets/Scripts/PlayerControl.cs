using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float impulseForce = 170000.0f;
    public float impulseTorque = 3000.0f;

    public GameObject player;

    Animator animController;
    Rigidbody rigidBody;

    public float kickForce = 10f;
    public Transform kickPoint;
    public LayerMask kickableLayer;

    // Array of animations
    private string[] kickAnimations = { "Kick1", "Kick2", "Kick3" };

    // Start is called before the first frame update
    void Start()
    {
        // Get references to the animation controller and player's corresponding rigid body
        animController = player.GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // W/A/S/D input as a combined rotation and movement vector
        Vector3 input = new Vector3(0, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Allow movement when input detected and not crouching and not kicking
        if (input.magnitude > 0.001f && !animController.GetBool("Crouch") && !animController.GetBool("Kick1") && !animController.GetBool("Kick2") && !animController.GetBool("Kick3"))
        {
            // Rotations are about y axis
            rigidBody.AddRelativeTorque(new Vector3(0, input.y * impulseTorque * Time.deltaTime, 0));
            // Motion is forward/backward (about z axis)
            rigidBody.AddRelativeForce(new Vector3(0, 0, input.z * impulseForce * Time.deltaTime));

            animController.SetBool("Walk", true);
        }
        else
        {
            animController.SetBool("Walk", false);
        }

        // Kicking with 'Space' key
        if (Input.GetKeyDown(KeyCode.Space) && !IsKicking())
        {
            PlayRandomKickAnimation();
            Kick();
        }

        // Crouching with 'C' key
        if (Input.GetKey(KeyCode.C))
        {
            animController.SetBool("Crouch", true);
        }
        else
        {
            animController.SetBool("Crouch", false);
        }
    }

    void Kick()
    {
        RaycastHit hit;
        if (Physics.Raycast(kickPoint.position, transform.forward, out hit, 1.5f, kickableLayer))
        {
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(transform.forward * kickForce, ForceMode.Impulse);
            }
        }
    }

    private void PlayRandomKickAnimation()
    {
        int randomIndex = Random.Range(0, kickAnimations.Length);
        string triggerName = kickAnimations[randomIndex];

        animController.SetTrigger(triggerName);

        StartCoroutine(ResetKickAnimation(triggerName));
    }

    private IEnumerator ResetKickAnimation(string triggerName)
    {
        yield return new WaitForSeconds(1.0f);
        animController.ResetTrigger(triggerName);
    }

    private bool IsKicking()
    {
        // Check if any of the kick animations are active
        foreach (string kick in kickAnimations)
        {
            if (animController.GetCurrentAnimatorStateInfo(0).IsName(kick))
            {
                return true;
            }
        }
        return false;
    }
}