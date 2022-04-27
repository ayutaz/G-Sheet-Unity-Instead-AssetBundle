using System.Collections.Generic;
using System.Linq;
using TMPro;
using UniRx;
using UnityEngine;

namespace _Project
{
    public class GameManager : MonoBehaviour
    {
        private CharacterDataModel _characterDataModel;
        [SerializeField] private UpdateCharacterInfoView updateCharacterInfoView;
        [SerializeField] private TMP_Dropdown dropdown;
        [SerializeField] private GameStatusView gameStatusView;

        private void Awake()
        {
            _characterDataModel = new CharacterDataModel();
        }

        private async void Start()
        {
            gameStatusView.UpdateStatus("get character data for spreadsheet");
            var characterData = await GetGameData.GetGameInfo<CharacterInfoList>();
            gameStatusView.UpdateStatus("update character scriptable object");
            _characterDataModel.CharacterInfoList = characterData.gameInfo;
            UpdateDropdownCharacterInfo(_characterDataModel.CharacterInfoList);
            dropdown.interactable = true;
            gameStatusView.UpdateStatus("done update character");

            dropdown.ObserveEveryValueChanged(value => value.value)
                .Subscribe(selectCharacterIndex =>
                {
                    var selectCharacterData = _characterDataModel.CharacterInfoList[selectCharacterIndex];
                    CharacterDataModel.CharacterDataDebugLog(selectCharacterData);
                    updateCharacterInfoView.UpdateInfoView(selectCharacterData);
                }).AddTo(this);
        }

        private void UpdateDropdownCharacterInfo(IEnumerable<CharacterInfo> characterInfoList)
        {
            dropdown.options.Clear();
            dropdown.options = characterInfoList.Select(characterSo => new TMP_Dropdown.OptionData(characterSo.name)).ToList();
        }
    }
}