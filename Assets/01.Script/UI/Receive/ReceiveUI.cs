using UnityEngine;
using UnityEngine.UI;

public class ReceiveUI : UIBase
{
    Image receiveImg;
    private void Awake()
    {
        UIManager.Instance.Add(this);
        receiveImg = GetComponent<Image>();
        gameObject.SetActive(false);
    }

    public override void OnUI()
    {
        base.OnUI();
        receiveImg.sprite = ResourcesManager.Instance.GetOnLoadedResource<Sprite>(ResourceStringHelper.ReceivceImg);
    }
}
