using System;
using System.Collections.Generic;
using UnityEngine;
public enum ColorName
{
    red,
    green,
    blue,
    cyan,
    yellow,
    orange,
    purple,
    magenta
}
public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if(null == instance)
            {
                GameObject obj = new GameObject("UIManager");
                DontDestroyOnLoad(obj);
                instance = obj.AddComponent<UIManager>();
            }
            return instance;
        }
    }


    private Dictionary<Type, UIBase> ui = new Dictionary<Type, UIBase>();
    private Dictionary<Type, string> uiPath = new Dictionary<Type, string>();




    private UIManager()
    {

    }


    public T Add<T>() where T : UIBase
    {
        Type key = typeof(T);
        if (!ui.ContainsKey(key))
        {
            if (uiPath.TryGetValue(key, out string pathValue))
            {
                GameObject loadedUIObj = ResourcesManager.Instance.GetOnLoadedResource<GameObject>(pathValue);
                GameObject makedUIObj = MonoBehaviour.Instantiate(loadedUIObj);
                T makedUIBase = makedUIObj.GetComponent<T>();
                ui.Add(key, makedUIBase);
                return makedUIBase;
            }
            else
            {
                LogHelper.Log($"{key.Name} 로드가 안된거 보니 로드를 안한 것 같음 혹은 경로가 이상하거나 어쨋든 문제임");
                return null;
            }
        }
        else
        {
            LogHelper.Log($"{key.Name} 이미 추가 된 UI!");
            return ui[key].GetComponent<T>();
        }
    }

    public void Add(UIBase _ui)
    {
        ui.Add(_ui.GetType(), _ui);
    }

    public void Remove<T>() where T : UIBase
    {
        Type key = typeof(T);
        if (ui.ContainsKey(key))
        {
            ui.Remove(key);
        }
        else
        {
            LogHelper.Log($"{key.Name} 그런 거 엄슴");
        }
    }

    public T GetUI<T>() where T : UIBase
    {
        Type key = typeof(T);
        if (ui.ContainsKey(key))
        {
            return ui[key] as T;
        }
        else
        {
            return Add<T>();
        }
    }

    public void Open<T>() where T : UIBase
    {
        Type key = typeof(T);
        if (ui.ContainsKey(key))
        {
            ui[key].OnUI();
        }
        else
        {
            LogHelper.Log($"{key.Name}  추가 되지 않은 UI");
        }
    }

    public void Close<T>() where T : UIBase
    {
        Type key = typeof(T);
        if (ui.ContainsKey(key))
        {
            ui[key].OffUI();
        }
        else
        {
            LogHelper.Log($"{key.Name}  추가 되지 않은 UI");
        }
    }

}