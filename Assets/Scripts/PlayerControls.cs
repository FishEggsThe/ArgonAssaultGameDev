using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    float xThrow, yThrow, fireThrow;
    float controlSpeed = 40f;
    float xRange = 10f;
    float yRange = 5f;

    float positionPitchFactor = -2f;
    float controlPitchFactor = -10f;
    float positionYawFactor = 2f;
    float controlRoll = -30f;

    [Tooltip("Thems laser particle systems the ship has")] [SerializeField] GameObject[] lasers;

    void Start()
    {
        
    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRoll;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");
        //Debug.Log(xThrow + ", " + yThrow);
        
        float xOffset = xThrow*controlSpeed*Time.deltaTime;
        float rawXPos = transform.localPosition.x+xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        
        float yOffset = yThrow*controlSpeed*Time.deltaTime;
        float rawYPos = transform.localPosition.y+yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3 (clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if(Input.GetAxis("Fire1") == 1) {
            SetLasersActive(true);
        } else {
            SetLasersActive(false);
        }
        //Debug.Log(fireThrow);
    }

    void SetLasersActive(bool isActive)
    {
        foreach(GameObject laser in lasers) {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
