using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem crashVFX;
    
    float delay = 1f;

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(this.name + "--Collided with--" + other.gameObject.name);
    }
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.name} **Triggered by** {other.gameObject.name}");
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        crashVFX.Play();
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadScene", delay);
    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
