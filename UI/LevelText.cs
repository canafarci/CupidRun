using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelText : MonoBehaviour
{
    TextMeshProUGUI _text;
    private void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
    private void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode arg1)
    {
        _text.text = (scene.buildIndex + 1).ToString();
    }
}