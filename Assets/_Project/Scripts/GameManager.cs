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
        [SerializeField] private GameStatusView gameStatusView;

        private async void Start()
        {
            gameStatusView.UpdateStatus("get character data for spreadsheet");
            var characterData = await GetGameData.GetGameInfo<CharacterInfoList>();
            gameStatusView.UpdateStatus("update character scriptable object");
            updateCharacterData.UpdateCharacter(characterData.gameInfo);
            UpdateDropdownCharacterInfo(updateCharacterData.GetCharacterList());
            dropdown.interactable = true;
            gameStatusView.UpdateStatus("done update character");

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