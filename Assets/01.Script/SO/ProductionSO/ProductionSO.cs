using UnityEngine;



[CreateAssetMenu(fileName = "NewItemData", menuName = "Game/Item Data")]
public class ProductionSO : ScriptableObject
{
    public string productionName;
    public string productionPrice;
    public string productionDiscription;
    public char productionRank;
    public Sprite productionImg;
}
