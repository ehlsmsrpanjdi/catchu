using System.Collections.Generic;
using UnityEngine;


public class ProductionDataManager : MonoBehaviour
{
    bool isInit = false;

    public List<ProductionSO> productionList = new List<ProductionSO>();

    readonly Dictionary<char, List<ProductionSO>> itemDictionary = new Dictionary<char, List<ProductionSO>>();

    static ProductionDataManager instance;

    public static ProductionDataManager Instance
    {
        get
        {
            if (null == instance)
            {
                GameObject obj = new GameObject("ProductionData");
                DontDestroyOnLoad(obj);
                instance = obj.AddComponent<ProductionDataManager>();
                instance.Init();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (false == isInit)
        {
            Init();
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Init()
    {
        isInit = true;
        foreach (ProductionSO production in productionList)
        {
            if (false == itemDictionary.ContainsKey(production.productionRank))
            {
                itemDictionary.Add(production.productionRank, new List<ProductionSO>());
            }
            itemDictionary[production.productionRank].Add(production);
        }
    }

    public ProductionSO GetProduction()
    {
        List<char> keys = new List<char>(itemDictionary.Keys);
        char randomKey = keys[Random.Range(0, keys.Count)];

        List<ProductionSO> list = itemDictionary[randomKey];
        int randomIndex = Random.Range(0, list.Count);
        return list[randomIndex];
    }

}
