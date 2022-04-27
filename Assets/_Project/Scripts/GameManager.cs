using System.Collections.Generic;
using System.Linq;
using TMPro;
using UniRx;
using UnityEngine;

namespace _Project
{
    public class GameManager : MonoBehaviour
    {
        private readonly GetGameData _gameData = new GetGameData();
        [SerializeField] private UpdateCharacterData updateCharacterData;
        [SerializeField] private UpdateCharacterInfoView updateCharacterInfoView;
        [SerializeField] private TMP_Dropdown dropdown;

        private async void Start()
        {
            var characterData = await GetGameData.GetGameInfo<CharacterInfoList>();
            updateCharacterData.UpdateCharacter(characterData.gameInfo);
            UpdateDropdownCharacterInfo(updateCharacterData.GetCharacterList());
            dropdown.interactable = true;

            dropdown.ObserveEveryValueChanged(value => value.value)
                .Subscribe(selectCharacterIndex =>
                {
                    var selectCharacterData = updateCharacterData.GetCharacterList();
                    updateCharacterInfoView.UpdateInfoView(selectCharacterData[selectCharacterIndex].CharacterInfo);
                }).AddTo(this);
        }

        private void UpdateDropdownCharacterInfo(IEnumerable<CharacterSO> characterSoList)
        {
            dropdown.options.Clear();
            dropdown.options = characterSoList.Select(characterSo => new TMP_Dropdown.OptionData(characterSo.name)).ToList();
        }
    }
}