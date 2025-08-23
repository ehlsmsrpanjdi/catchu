using System.Collections;
using UnityEngine;

public class ParticleUI : UIBase
{
    Coroutine closeCoroutineValue;

    private void Awake()
    {
        UIManager.Instance.Add(this);
        gameObject.SetActive(false);
    }

    public override void OnUI()
    {
        base.OnUI();
        if (closeCoroutineValue != null)
        {
            StopCoroutine(closeCoroutineValue);
        }
        closeCoroutineValue = StartCoroutine(closeCoroutine());
    }

    IEnumerator closeCoroutine()
    {
        yield return new WaitForSeconds(5f);
        OffUI();
    }

    public override void OffUI()
    {
        base.OffUI();
        if (closeCoroutineValue != null)
        {
            StopCoroutine(closeCoroutineValue);
        }
    }
}
