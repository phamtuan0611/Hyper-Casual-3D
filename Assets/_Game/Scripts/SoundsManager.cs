using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [Header(" Sounds ")]
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource doorHitSound;
    [SerializeField] private AudioSource runnerDieSound;
    [SerializeField] private AudioSource levelCompleteSound;
    [SerializeField] private AudioSource gameOverSound;

    // Start is called before the first frame update
    void Start()
    {
        buttonSound.Stop();
        doorHitSound.Stop();
        runnerDieSound.Stop();
        levelCompleteSound.Stop();
        gameOverSound.Stop();

        PlayerDectetion.onDoorsHit += PlayDoorHitSound;

        GameManager.onGameStateChanged += GameStateChangedCallBack;

        Enemy.onRunnerDied += PlayRunnerDieSound;
    }

    private void OnDestroy()
    {
        PlayerDectetion.onDoorsHit -= PlayDoorHitSound;

        GameManager.onGameStateChanged -= GameStateChangedCallBack;

        Enemy.onRunnerDied -= PlayRunnerDieSound;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlayDoorHitSound()
    {
        doorHitSound.Play();
    }

    private void GameStateChangedCallBack(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.LevelComplete)
            levelCompleteSound.Play();
        else if (gameState == GameManager.GameState.GameOver)
            gameOverSound.Play();
    }

    private void PlayRunnerDieSound()
    {
        runnerDieSound.Play();
    }
}
