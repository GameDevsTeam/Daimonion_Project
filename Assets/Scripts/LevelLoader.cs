using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public IEnumerator LoadLevel(int levelIndex)
    {
        StopPlayerScript();

        // Play animation
        transition.SetTrigger("Start");

        // Wait 1s
        yield return new WaitForSeconds(transitionTime);

        // Load scene
        SceneManager.LoadScene(levelIndex);
    }

    public void StopPlayerScript()
    {
        GameObject.Find("player_0").GetComponent<Player>().enabled = false;
    }

    public void RestartPlayerScript()
    {
        GameObject.Find("player_0").GetComponent<Player>().enabled = true;
    }
}
