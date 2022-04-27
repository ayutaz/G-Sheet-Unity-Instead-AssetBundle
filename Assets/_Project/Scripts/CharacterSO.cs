using UnityEngine;

namespace _Project
{
    [CreateAssetMenu(fileName = "Character", menuName = "Character", order = 0)]
    public class CharacterSO : ScriptableObject
    {
        public CharacterInfo CharacterInfo;
    }
}