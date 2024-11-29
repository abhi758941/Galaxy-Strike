using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSceneManager : MonoBehaviour
{
    public void reloadLevel()
    {
        StartCoroutine(ReloadLevelRoutine());
    }
    IEnumerator ReloadLevelRoutine()
    {
        yield return new WaitForSeconds(1f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);        
    }
}
