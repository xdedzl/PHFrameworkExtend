using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using PHFramework.UI;

public class ReddotDemo : MonoBehaviour
{
    public PHLayoutGroup toggles;
    void Awake()
    {
        // 初始化
        string path = $"{Application.dataPath}/PHFramework/Extend/Core/Modules/UI/Reddot/Demo/ReddotData.json";
        var datas = JsonConvert.DeserializeObject<ReddotData[]>(File.ReadAllText(path));
        ReddotManager.Instance.Init(datas);
        var keys = ReddotManager.Instance.GetLeafKeys();

        foreach (var key in keys)
        {
            var obj = toggles.AddEntity();

            Toggle toggle = obj.GetComponent<Toggle>();

            toggle.onValueChanged.AddListener((v) =>
            {
                ReddotManager.Instance.MarkReddot(key, v);
            });
            toggle.transform.Find("Label").GetComponent<Text>().text = key;
        }
    }
}
