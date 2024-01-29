using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.VFX;

public class Spin : MonoBehaviour
{
    public float speedForDistance = 50f;
    public GameObject player;

    private bool isPlayerMoving = false;
    private bool PlayerNotMoving = true;
    private float currentRotationSpeed = 0f;
    public float rotationSpeedDecreaseFactor = 1f; // Adjust this value to control how quickly rotation speed decreases
    public float DistanceFromCube;
    public float idleTimeThreshold = 13f; // Adjust this value based on your desired idle time
    private float currentIdleTime = 0f;
    private Rigidbody rb;
    public GameObject Imapct;
    public GameObject fire;
    public GameObject ground;
    public GameObject Cube;
    public GameObject objectToActivate;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        isPlayerMoving = Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f || Vector3.Distance(player.transform.position, transform.position) < DistanceFromCube;
        PlayerNotMoving = Mathf.Abs(horizontalInput) < 0.1f || Mathf.Abs(verticalInput) < 0.1f || Vector3.Distance(player.transform.position, transform.position) > DistanceFromCube;

        if (isPlayerMoving)
        {
            currentRotationSpeed = 180 * speedForDistance / Vector3.Distance(player.transform.position, transform.position);
            transform.Rotate(Vector3.up, currentRotationSpeed * Time.deltaTime);
        }
        if (PlayerNotMoving)
        {
            // If the player is not moving, gradually decrease the rotation speed
            currentRotationSpeed = Mathf.Lerp(currentRotationSpeed, 0f, rotationSpeedDecreaseFactor * Time.deltaTime);
            transform.Rotate(Vector3.up, currentRotationSpeed * Time.deltaTime);
        }
        else
        {
            currentRotationSpeed = 150;
            transform.Rotate(Vector3.up, currentRotationSpeed * Time.deltaTime);
        }


        if (currentRotationSpeed < 150)
        {
            currentIdleTime = 0f;

        }
        if (currentRotationSpeed > 150)
        {
            currentIdleTime += Time.deltaTime;

        }
        if (currentIdleTime >= idleTimeThreshold)
        {
            rb.isKinematic = false;

            StartCoroutine(ActivateAfterDelay(1.2f));
           
        }
        
    }

        IEnumerator ActivateAfterDelay(float delay)
        {
            // Wait for the specified delay
            yield return new WaitForSeconds(delay);

            // Activate the object after the delay
            if (fire != null)

                // Play the fire Particle System
                fire.SetActive(true);
            Imapct.SetActive(true);
        currentRotationSpeed = Mathf.Lerp(currentRotationSpeed, 0f, rotationSpeedDecreaseFactor * Time.deltaTime);
        transform.Rotate(Vector3.up, currentRotationSpeed * Time.deltaTime);
    }
    

    }

    




