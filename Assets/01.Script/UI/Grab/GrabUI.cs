using DG.Tweening;

public class GrabUI : UIBase
{
    public bool isGrab { private set; get; } = false;

    private void Start()
    {
        UIManager.Instance.Add(this);
    }

    public void Grab()
    {
        isGrab = true;
        Sequence grabSequence = DOTween.Sequence();
        grabSequence.Append(transform.DOMoveY(transform.position.y -270, 5f));
        grabSequence.AppendInterval(2f);
        grabSequence.Append(transform.DOMoveY(transform.position.y, 5f));
    }
}
