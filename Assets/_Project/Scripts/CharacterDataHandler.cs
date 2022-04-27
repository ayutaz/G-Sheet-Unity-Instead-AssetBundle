﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project
{
    public class CharacterDataHandler : MonoBehaviour
    {
        [SerializeField] private List<CharacterSO> characterSoList;

        public List<CharacterSO> GetCharacterList() => characterSoList;

        public void UpdateCharacter(List<CharacterInfo> characterInfoList)
        {
            foreach (var (character, index) in characterSoList.Select((info, index) => (info, index)))
            {
                character.CharacterInfo.name = characterInfoList[index].name;
                character.CharacterInfo.atk = characterInfoList[index].atk;
                character.CharacterInfo.def = characterInfoList[index].def;
                character.CharacterInfo.hp = characterInfoList[index].hp;
                character.CharacterInfo.mp = characterInfoList[index].mp;
                character.CharacterInfo.uuid = characterInfoList[index].uuid;
            }
        }

        public static void CharacterDataDebugLog(CharacterInfo characterInfo)
        {
            Debug.Log("name : " + characterInfo.name + ", atk : " + characterInfo.atk + ", def : " + characterInfo.def + ", hp : " + characterInfo.hp + ", mp : " + characterInfo.mp);
        }
    }
}