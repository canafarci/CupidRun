using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestartButton : MonoBehaviour
{
    public void RestartGame()
    {

        SceneManager.LoadScene("New Scene 2");

    }
}
