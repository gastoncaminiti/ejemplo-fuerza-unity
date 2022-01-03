using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float delayTime = 1f;
    [SerializeField] AudioClip winSFX;
    [SerializeField] AudioClip explodeSFX;

    [SerializeField] ParticleSystem winParticle;
    [SerializeField] ParticleSystem explodeParticle;
    
    //REFERENCE VARIABLES
    private AudioSource myAudioSource;

    bool isTransitioning = false;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) { return; }

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
        isTransitioning = true;
        DisablePlayerControl();
        explodeParticle.Play();
        myAudioSource.Stop();
        myAudioSource.PlayOneShot(explodeSFX);
        Invoke("ReloadLevel", delayTime);
    }

    private void StartNextSequence()
    {
        isTransitioning = true;
        DisablePlayerControl();
        winParticle.Play();
        myAudioSource.Stop();
        myAudioSource.PlayOneShot(winSFX);
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
