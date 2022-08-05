using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleLoaderScript : MonoBehaviour
{
    [SerializeField]
    Animator transition;
    [SerializeField]
    float transitionTime = 1f;

    public void LoadBattleScene(string battleSceneName)
    {
        StartCoroutine(LoadBattle(battleSceneName));
    }

    public IEnumerator LoadBattle(string battleSceneName)
    {

        // Play animation
        transition.SetTrigger("Start");

        // Wait 1s
        yield return new WaitForSeconds(transitionTime);

        // Load scene
        SceneManager.LoadScene(battleSceneName);
    }
}
