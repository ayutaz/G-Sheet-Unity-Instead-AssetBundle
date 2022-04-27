using UnityEngine;

namespace _Project
{
    public class GameManager : MonoBehaviour
    {
        private readonly GetGameData _gameData = new GetGameData();
        [SerializeField] private UpdateCharacterData updateCharacterData;

        private async void Start()
        {
            var characterData = await GetGameData.GetGameInfo<CharacterInfoList>();
            updateCharacterData.UpdateCharacter(characterData.gameInfo);
        }
    }
}