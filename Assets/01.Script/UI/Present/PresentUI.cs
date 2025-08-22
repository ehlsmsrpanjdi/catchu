using UnityEngine;

public class PresentUI : UIBase
{
    private void Start()
    {
        UIManager.Instance.Add(this);
    }
}
