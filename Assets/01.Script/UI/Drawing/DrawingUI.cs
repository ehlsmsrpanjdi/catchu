using UnityEngine;

public class DrawingUI : UIBase
{
    private void Start()
    {
        UIManager.Instance.Add(this);
    }
}
