using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    [SerializeField] Animator fadeTransition;
    [SerializeField] GameObject transitionScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeInitialScene()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void PlayerDeath()
    {
        StartCoroutine(LoadLevel(2));
    }

    public void BackToMainMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void PlayerVictory()
    {
        StartCoroutine(LoadLevel(3));
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    IEnumerator LoadLevel(int sceneIndex)
    {
        transitionScreen.SetActive(true);

        fadeTransition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(sceneIndex);
    }
}
