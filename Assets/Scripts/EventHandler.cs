using System;
using UnityEngine;

public static class EventHandler
{
    public static event Action<int> OnColiderDestroy;
    public static event Action OnGameEnd;
    public static event Action<int> OnGameEndScore;
    public static event Action onBullateSpawn;
    public static event Action<AudioSource> OnAstroidCollision;

    public static event Action OnGameStart;

    public static void ColiderDestroy(int score) => OnColiderDestroy?.Invoke(score);

    public static void GameEnd() => OnGameEnd?.Invoke();

    public static void GameEndScore(int score) => OnGameEndScore?.Invoke(score);

    public static void GameStart() => OnGameStart?.Invoke();

    public static void BullateSpawn() => onBullateSpawn?.Invoke();

    public static void AstroidCollision(AudioSource audioSource) => OnAstroidCollision?.Invoke(audioSource);
}
