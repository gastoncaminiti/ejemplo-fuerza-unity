using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float delayTime = 1f;

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("IS A FRIEND");
                break;
            case "Finish":
                StartNextSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartCrashSequence()
    {
        DisablePlayerControl();
        Invoke("ReloadLevel", delayTime);
    }

    private void StartNextSequence()
    {
        DisablePlayerControl();
        Invoke("LoadNextLevel", delayTime);
    }

    private void DisablePlayerControl()
    {
        GetComponent<Movement>().enabled = false;
    }

    private void ReloadLevel()
    {
        //RELOAD CODE
        int curretSceneIndex = GetCurretSceneIndex();
        SceneManager.LoadScene(curretSceneIndex);
    }

    private void LoadNextLevel()
    {
        int nextSceneIndex = GetCurretSceneIndex() + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    private int GetCurretSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
