using UnityEngine;
using PHFramework.UI;
using System.Text.RegularExpressions;

public class SettingPanel : PanelBase {

    Regex regex = new Regex("^[0-9]*$");

    public override void Reg()
    {
        Level = 10;

        (this["ConfirmBtn"] as PHButton).AddListener(() =>
        {
            int width, height;
            if (!regex.IsMatch((this["Width"] as PHInputField).inputField.text) || !regex.IsMatch((this["Height"] as PHInputField).inputField.text))
            {
                Debug.Log("请输出数字");
                return;
            }

            width = int.Parse((this["Width"] as PHInputField).inputField.text);
            height = int.Parse((this["Height"] as PHInputField).inputField.text);

            bool isFullScreen = (this["FullScreen"] as PHToggle).toggle.isOn;

            Screen.SetResolution(width, height, isFullScreen);
        });

        (this["Esc"] as PHButton).button.onClick.AddListener(() =>
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        });

        (this["Back"] as PHButton).button.onClick.AddListener(() =>
        {
            UIHelper.Instance.Close(UIName.Setting);
        });
    }

    public override void OnOpen(params object[] args)
    {
        gameObject.SetActive(true);
    }

    public override void OnClose()
    {
        gameObject.SetActive(false);
    }
}
