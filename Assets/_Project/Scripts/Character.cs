using System.Collections.Generic;
using UnityEngine;

namespace _Project
{
    [CreateAssetMenu(fileName = "Character", menuName = "Character", order = 0)]
    public class Character : ScriptableObject
    {
        public List<CharacterInfo> characterInfoList;
    }
}