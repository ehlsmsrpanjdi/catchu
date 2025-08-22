using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrawingButton : Button
{
    Image parentImg;
    bool isMouseHover = false;

    protected override void Awake()
    {
        base.Awake();
        parentImg = transform.parent.GetComponent<Image>();
    }


    public override void OnPointerDown(PointerEventData _data)
    {
        if (true == UIManager.Instance.GetUI<GrabUI>().isGrab)
        {
            return;
        }
        LogHelper.Log("눌림");
        parentImg.sprite = ResourcesManager.Instance.GetOnLoadedResource<Sprite>(ResourceStringHelper.OnClickedImg);
        isMouseHover = true;
    }

    public override void OnPointerUp(PointerEventData _data)
    {
        if (false == isMouseHover)
        {
            return;
        }
        LogHelper.Log("때임");
        parentImg.sprite = ResourcesManager.Instance.GetOnLoadedResource<Sprite>(ResourceStringHelper.UnClickedImg);
        GrabUI grabUI = UIManager.Instance.GetUI<GrabUI>();
        grabUI.Grab();
    }

    public override void OnPointerExit(PointerEventData _data)
    {
        isMouseHover = false;
    }

}
