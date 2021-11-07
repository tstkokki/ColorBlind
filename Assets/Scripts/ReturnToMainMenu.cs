using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    public int levelIndex = 0;
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(levelIndex);
    }
}
