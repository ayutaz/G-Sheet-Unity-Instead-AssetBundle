using System;
using UnityEngine;

namespace _Project
{
    public class GameManager : MonoBehaviour
    {
        private readonly GetGameData _gameData = new GetGameData();

        private void Start()
        {
            Debug.Log(_gameData.GetGameInfo<CharacterInfo>());
        }
    }
}