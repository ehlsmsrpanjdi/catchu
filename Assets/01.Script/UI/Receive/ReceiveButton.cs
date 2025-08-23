using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReceiveButton : Button
{
    public override void OnPointerDown(PointerEventData _data)
    {
        UIManager uiManager = UIManager.Instance;
        uiManager.GetUI<ReceiveUI>().OnClickButton();
    }
}
