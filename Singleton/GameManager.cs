using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Saver Saver {get {return _saver; } }
    public SceneLoader SceneLoader { get { return _sceneLoader; } }
    public AnimationManager AnimationManager { get { return _animationManager; } }
    public References References { get { return _references; } }
    public CameraController CameraController { get { return _cameraController;} }
    public AudioManager AudioManager { get { return _audioManager;} }

    Saver _saver;
    SceneLoader _sceneLoader;
    GameStart _gameStart;
    AnimationManager _animationManager;
    References _references;
    CameraController _cameraController;
    AudioManager _audioManager;

    public static GameManager Instance { get; private set; }
    void Awake()
    {
        if (Instance)
            Destroy(gameObject);
        else
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }

        _saver = GetComponent<Saver>();
        _sceneLoader = GetComponent<SceneLoader>();
        _gameStart = GetComponent<GameStart>();
        _animationManager = GetComponent<AnimationManager>(); 
        _references = GetComponent<References>();
        _cameraController = GetComponent<CameraController>();
        _audioManager = GetComponentInChildren<AudioManager>();
    }

    private void OnEnable() => SceneManager.activeSceneChanged += OnSceneLoaded;
    private void OnDisable() => SceneManager.activeSceneChanged -= OnSceneLoaded;

    private void OnSceneLoaded(Scene arg0, Scene arg1)
    {
        _gameStart.enabled = true;
    }
}
