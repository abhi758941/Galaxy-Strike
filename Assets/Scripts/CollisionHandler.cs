using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject playerDestroyVFX;
    GameSceneManager gameSceneManager;
    private void Start() 
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }
    private void OnCollisionEnter(Collision other) 
    {
        PlayerCollision();
    }

    private void PlayerCollision()
    {
        gameSceneManager.reloadLevel();
        Instantiate(playerDestroyVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
