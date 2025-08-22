using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    public virtual void OnUI()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void OffUI()
    {
        this.gameObject.SetActive(false);
    }

}