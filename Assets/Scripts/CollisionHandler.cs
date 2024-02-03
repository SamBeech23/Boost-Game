using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] int sceneDelay = 1;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem successParticles;

    AudioSource audioSource;

    bool isTransitioning = false;
    bool collisionOn = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        RespondToDebugKeys();
    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKey(KeyCode.L))
        {
            LoadNextLevel();
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            if (collisionOn)
            {
                collisionOn = false;
            }
            else if (!collisionOn)
            {
                collisionOn = true;
            }
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning || !collisionOn){return;}
        {
            switch (other.gameObject.tag)
            {
                case "Friendly":
                    break;

                case "Finish":
                    StartFinishSequence();
                    break;

                default:
                    StartCrashSequence();
                    break;
            }
        }
    }

    // Crash methods 
    void StartCrashSequence()
    {
        isTransitioning = true;
        crashParticles.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", sceneDelay);
    }

    void StartFinishSequence()
    {
        isTransitioning = true;
        successParticles.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", sceneDelay);
    }

    // Scene handler methods
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }
}
