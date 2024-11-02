using UnityEngine;
using PHFramework.UI;

public class MainPanel : PanelBase {

    public override void Reg()
    {
        Level = 1;
        (this["CreateBtn"] as PHButton).button.onClick.AddListener(() => { OnClick(UIName.Create); });
        (this["PowerBtn"] as PHButton).button.onClick.AddListener(() => { OnClick(UIName.ShowPower); });
        (this["AdjustBtn"] as PHButton).button.onClick.AddListener(() => { OnClick(UIName.Adjust); });
    }

    /// <summary>
    /// 处理各个按钮的点击事件
    /// </summary>
    /// <param name="_type"></param>
    private void OnClick(string _type)
    {
        UIHelper.Instance.Open(_type);
    }
}