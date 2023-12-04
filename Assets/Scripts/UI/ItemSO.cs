using UnityEngine;


[CreateAssetMenu(fileName = "New Item Upgrade", menuName = "Item Upgrade")]
public class ItemSO : ScriptableObject
{
    public Sprite background;
    public Sprite itemImg;
    public string description;
    public string costUpgrade;
}
