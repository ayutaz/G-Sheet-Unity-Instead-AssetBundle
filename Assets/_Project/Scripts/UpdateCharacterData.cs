using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project
{
    public class UpdateCharacterData : MonoBehaviour
    {
        [SerializeField] private List<CharacterSO> characterSoList;
        
        public List<CharacterSO> GetCharacterList() => characterSoList;

        public void UpdateCharacter(List<CharacterInfo> characterInfoList)
        {
            foreach (var (character, index) in characterSoList.Select((info, index) => (info, index)))
            {
                UniTask.RunOnThreadPool(() =>
                {
                    character.CharacterInfo.name = characterInfoList[index].name;
                    character.CharacterInfo.atk = characterInfoList[index].atk;
                    character.CharacterInfo.def = characterInfoList[index].def;
                    character.CharacterInfo.hp = characterInfoList[index].hp;
                    character.CharacterInfo.mp = characterInfoList[index].mp;
                    character.CharacterInfo.uuid = characterInfoList[index].uuid;
                });
            }
        }
    }
}