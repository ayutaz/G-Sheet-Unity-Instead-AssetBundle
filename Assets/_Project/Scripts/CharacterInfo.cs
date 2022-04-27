using System.Collections.Generic;

namespace _Project
{
    [System.Serializable]
    public class CharacterInfo
    {
        public string uuid;
        public string name;
        public int atk;
        public int def;
        public int hp;
        public int mp;
    }
    
    [System.Serializable]
    public class CharacterInfoList
    {
        public List<CharacterInfo> gameInfo;
    }
}