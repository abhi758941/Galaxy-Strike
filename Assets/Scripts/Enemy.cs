using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    [SerializeField] int hitpoints = 100;
    [SerializeField] int scoreValue = 10;
    Scoreboard scoreboard;
    private void Start() 
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

    }

    private void ProcessHit()
    {
        hitpoints -= 20;
        if (hitpoints <= 0)
        {
            scoreboard.IncreaseScore(scoreValue);
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
