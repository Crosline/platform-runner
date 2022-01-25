using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {
    public static event Action<GameState> OnBeforeStateChanged;
    public static event Action<GameState> OnAfterStateChanged;

    public GameState State { get; private set; }

    /*[SerializeField]
    private InputHandler _inputHandler;*/

    // Start is called before the first frame update
    void Start() {
        /*if (_inputHandler == null) {
            _inputHandler = FindObjectOfType<InputHandler>();
        }*/

        ChangeState(GameState.Starting);
    }

    public void ChangeState(GameState newState) {
        OnBeforeStateChanged?.Invoke(newState);

        State = newState;
        switch (newState) {
            case GameState.Starting:
                Init();
                break;
            case GameState.Running:
                Running();
                break;
            case GameState.Painting:
                Painting();
                break;
            case GameState.Restart:
                Restart();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnAfterStateChanged?.Invoke(newState);

        Debug.Log($"New State: {newState}");
    }

    #region State Functions

    private void Init() {
        throw new NotImplementedException();
        //ChangeState(GameState.Running);
    }

    private void Painting() {
        throw new NotImplementedException();
    }

    private void Running() {
        throw new NotImplementedException();
    }

    private void Restart() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    #endregion

    #region Button Functions

    public void RestartGame() {
        ChangeState(GameState.Restart);
    }
    public void QuitGame() {
        Application.Quit();
    }

    #endregion

    [Serializable]
    public enum GameState {
        Starting = 0, // Initializing the grid etc.
        Running = 1, // Waiting Input from Procution Menu(BuildProduct) / Game Board(ProcutionSelect)
        Painting = 2, // Started to execute inputs
        Restart = 3, //
    }
}