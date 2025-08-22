using UnityEngine;

public class ResourceLoader : MonoBehaviour
{
    private void Awake()
    {
        LoadResource();
    }

    void Start()
    {
        
    }

    async void LoadResource()
    {
        await ResourcesManager.Instance.LoadResource<Sprite>(ResourceStringHelper.OnClickedImg);
        await ResourcesManager.Instance.LoadResource<Sprite>(ResourceStringHelper.UnClickedImg);
    }

}
