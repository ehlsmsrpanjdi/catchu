using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReceiveButton : Button
{
    public override void OnPointerDown(PointerEventData _data)
    {
        UIManager uiManager = UIManager.Instance;
        uiManager.Close<ReceiveUI>();
        uiManager.Close<DrawPopupUI>();
        uiManager.Open<DrawingUI>();
        uiManager.Open<PresentUI>();
        uiManager.Open<BackGroundUI>();
    }
}
