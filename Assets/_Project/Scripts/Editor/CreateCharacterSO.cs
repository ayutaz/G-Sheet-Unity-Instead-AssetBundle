using UnityEditor;

namespace _Project.Editor
{
    public class CreateCharacterSO : EditorWindow
    {
        private const int maxSOCount = 30;
        [MenuItem("Tools/Create Character SO")]
        private static void CreateSO()
        {
            for (var index = 0; index < maxSOCount; index++)
            {
                var instance = CreateInstance<CharacterSO>();
                AssetDatabase.CreateAsset(instance, $"Assets/_Project/CharacterData/Character{index}.asset");
                AssetDatabase.Refresh();
            }
        }
    }
}