using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public GameObject player;

    [Header("Camera Settings")]
    public float distance = 5f;   // Distance behind the player
    public float height = 3f;     // Height above the player
    public float smoothSpeed = 0.125f;  // Smoothing factor for movement
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Calculate desired position:
        //   - Start at the player's position.
        //   - Move back along the player's forward vector.
        //   - Raise the camera by 'height'.
        Vector3 desiredPosition = player.transform.position
                                  - player.transform.forward * distance
                                  + Vector3.up * height;

        // Smoothly move the camera to the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Calculate a look-at point on the vehicle.
        // This can be adjusted (e.g., raising it slightly) so the camera looks at the target's back.
        Vector3 lookAtPoint = player.transform.position + Vector3.up * (height * 0.5f);
        transform.LookAt(lookAtPoint);
    }
}