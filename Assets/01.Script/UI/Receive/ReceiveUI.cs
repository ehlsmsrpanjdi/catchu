using DG.Tweening;
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

    public override void OffUI()
    {
        base.OffUI();
        transform.DOKill();
    }

    public void OnClickButton()
    {
        UIManager uiManager = UIManager.Instance;

        DrawPopupUI drawPopupUI = uiManager.GetUI<DrawPopupUI>();
        drawPopupUI.CloseString();

        Sequence receiveSequence = DOTween.Sequence();
        receiveSequence.Append(drawPopupUI.gameObject.transform.DOScale(new Vector3(1.7f, 1.7f, 1.7f), 0.3f));
        receiveSequence.Append(drawPopupUI.gameObject.transform.DOScale(new Vector3(0.3f, 0.3f, 0.3f), 0.6f));
        receiveSequence.onComplete = () =>
        {
            uiManager.Close<ReceiveUI>();
            uiManager.Close<ParticleUI>();
            uiManager.Close<DrawPopupUI>();
            uiManager.Open<DrawingUI>();
            uiManager.Open<PresentUI>();
            uiManager.Open<BackGroundUI>();
        };
    }
}
