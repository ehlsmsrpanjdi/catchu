using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DrawPopupUI : UIBase
{
    [SerializeField] Image FrontPopup;
    [SerializeField] Image BackPresent;
    [SerializeField] Image BackPopup;
    [SerializeField] Image MainBackGround;

    private void Reset()
    {
        FrontPopup = this.TryGetChildComponent<Image>("Img_FrontPopup");
        BackPopup = this.TryGetChildComponent<Image>("Img_BackPopup");
        BackPresent = this.TryGetChildComponent<Image>("Img_BackPresent");
        MainBackGround = GetComponent<Image>();
    }

    private void Start()
    {
        UIManager.Instance.Add(this);
        gameObject.SetActive(false);
    }

    public override void OnUI()
    {
        FrontPopup.fillAmount = 1f;
        MainBackGround.color = new Color(1f,1f,1f,0.5f);
        BackPopup.color = new Color(0.98f, 0.63f, 0.95f, 1f);
        BackPresent.gameObject.transform.localScale = Vector3.one;
        BackPopup.gameObject.SetActive(true);
        base.OnUI();
        Vector3 startScale = new Vector3(0.2f, 0.2f, 0.2f);
        Vector3 endScale = Vector3.one;

        transform.DOScale(endScale, 0.5f).From(startScale);
    }

    public void FrontImageFilled(float _amount)
    {
        FrontPopup.fillAmount = _amount;
    }

    public void EndFrontImg()
    {
        StartCoroutine(PopupOffCoroutine());
    }

    IEnumerator PopupOffCoroutine()
    {
        DrawPopupHandle popUpHandler = UIManager.Instance.GetUI<DrawPopupHandle>();
        popUpHandler.gameObject.SetActive(false);

        while (FrontPopup.fillAmount > 0.05f)
        {
            FrontPopup.fillAmount -= Time.deltaTime * 0.5f;
            yield return null;
        }

        Sequence backPresentSequence = DOTween.Sequence();
        backPresentSequence.Append(BackPresent.gameObject.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.3f));
        backPresentSequence.Append(BackPresent.gameObject.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f));
        backPresentSequence.onComplete = () => { RemoveBack(); };

        FrontPopup.gameObject.SetActive(false);

        yield return null;
    }

    void RemoveBack()
    {
        MainBackGround.color = new Color(1f, 1f, 1f, 0.0f);
        BackPopup.color = new Color(1f, 1f, 1f, 0.0f);
    }
}
