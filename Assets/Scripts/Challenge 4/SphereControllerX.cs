using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private int inputID = 2;

    private float normalSpeed = 500f;
    private float energySpeed = 1000f;

    public GameObject powerupIndicator;
    public bool hasPowerup;
    public float powerUpDuration = 5f;

    public GameObject energyupIndicator;
    public bool hasEnergyup;
    public float energyupDuration = 5f;

    public ParticleSystem energyParticle;

    private float normalStrength = 10; // how hard to hit enemy without powerup
    private float powerupStrength = 25; // how hard to hit enemy with powerup
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical" + inputID);

        if (hasEnergyup)
        {
            playerRb.AddForce(focalPoint.transform.forward * verticalInput * energySpeed * Time.deltaTime);
        }
        else
        {
            playerRb.AddForce(focalPoint.transform.forward * verticalInput * normalSpeed * Time.deltaTime);
        }

        // Set powerup indicator position to beneath player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);
        energyupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);
        energyParticle.transform.position = transform.position + new Vector3(0, -0.6f, 0);
    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCooldown());
        }

        if (other.gameObject.CompareTag("Energyup"))
        {
            hasEnergyup = true;
            energyupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(EnergyupCooldown());
            energyParticle.Play();
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    IEnumerator EnergyupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasEnergyup = false;
        energyupIndicator.SetActive(false);
        energyParticle.Stop();
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position -  transform.position; 
           
            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }
        }
    }
}
