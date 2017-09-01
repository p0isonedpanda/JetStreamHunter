using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject startMenu, levelSelectMenu, exitConfirmMenu, loadingMenu;
    public Slider loadingBar;

    // Pretty self explanatory stuff here, functions to be called on button presses
    public void OpenMenu (GameObject newMenu)
    {
        startMenu.SetActive(false);
        newMenu.SetActive(true);
    }

    public void ExitGame ()
    {
        exitConfirmMenu.SetActive(true);
    }

    public void ConfirmExit (bool confirmation)
    {
        if (confirmation)
            Application.Quit();
        else
            exitConfirmMenu.SetActive(false);
    }

    public void BackToStartMenu (GameObject currentMenu)
    {
        currentMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    public void LevelSelect (string levelName)
    {
        levelSelectMenu.SetActive(false);
        loadingMenu.SetActive(true);
        StartCoroutine(StartLoadLevel(levelName));
    }

    // Coroutine to be called on loading level
    IEnumerator StartLoadLevel (string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f); // Clamp loading progress value between 0-1 and normalise it so we can display it
            loadingBar.value = progress;

            yield return null; // Wait till next frame before we continue again
        }
    }
}
