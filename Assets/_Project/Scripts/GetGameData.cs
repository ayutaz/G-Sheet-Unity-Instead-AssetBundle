using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace _Project
{
    public class GetGameData
    {
        private const string URL = "url";
        private const string SheetName = "gameInfo";

        public static async UniTask<T> GetGameInfo<T>()
        {
            var request = UnityWebRequest.Get($"{URL}?sheetName={SheetName}");
            await request.SendWebRequest();
            if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError or UnityWebRequest.Result.DataProcessingError)
            {
                Debug.Log("fail to get card info from google sheet");
            }
            else
            {
                var json = request.downloadHandler.text;
                Debug.Log("json: " + json);
                var data = JsonUtility.FromJson<T>(json);
                return data;
            }

            return default;
        }
    }
}
