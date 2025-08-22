using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GrabUI : UIBase
{
    public bool isGrab { private set; get; } = false;
    [SerializeField] GameObject presentImg;

    private void Reset()
    {
        presentImg = this.TryGetChildComponent<Image>("Img_Present").gameObject;
    }

    private void Awake()
    {
        presentImg.SetActive(false);
    }

    private void Start()
    {
        UIManager.Instance.Add(this);
    }

    public void Grab()
    {
        isGrab = true;
        Sequence grabSequence = DOTween.Sequence();
        grabSequence.Append(transform.DOMoveY(transform.position.y - 270, 2.5f));
        grabSequence.AppendInterval(1f);
        grabSequence.AppendCallback(() => presentImg.SetActive(true));
        grabSequence.Append(transform.DOMoveY(transform.position.y, 2.5f));
        grabSequence.onComplete = () => { SuccedGrab(); };
    }

    void SuccedGrab()
    {
        UIManager manager = UIManager.Instance;
        manager.GetUI<PresentUI>().OffUI();
        manager.GetUI<DrawingUI>().OffUI();
        manager.GetUI<BackGroundUI>().OffUI();
        manager.GetUI<DrawPopupUI>().OnUI();
        isGrab = false;
        presentImg.SetActive(false);
    }
}
