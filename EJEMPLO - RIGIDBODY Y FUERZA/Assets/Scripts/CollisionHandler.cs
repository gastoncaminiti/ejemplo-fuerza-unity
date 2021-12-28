using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("IS A FRIEND");
                break;
            case "Fuel":
                Debug.Log("IS A FUEL");
                break;
            case "Finish":
                Debug.Log("WIN");
                break;
            default:
                Debug.Log("GAME OVER");
                break;
        }
    }
}
