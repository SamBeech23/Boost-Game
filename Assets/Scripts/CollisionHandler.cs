using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] int sceneDelay = 1;
    private void OnCollisionEnter(Collision other) 
    {

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly object");
                break;

            case "Finish":
                StartFinishSequence();
                break;

            default:
                StartCrashSequence();
                break;
        }
    }

    // Crash methods 
    void StartCrashSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", sceneDelay);
    }

    void StartFinishSequence()
    {
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
