using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    private void OnEnable() => GameStart.OnGameStart += OnGameStart;
    private void OnDisable() => GameStart.OnGameStart -= OnGameStart;


    void OnGameStart() => gameObject.SetActive(false);

}
