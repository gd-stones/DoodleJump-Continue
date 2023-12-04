using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ItemUpgradeDisplay : MonoBehaviour
{
    public ItemSO item;

    public Image background;
    public Image itemImg;

    public TextMeshProUGUI description;
    public TextMeshProUGUI costUpgrade;

    private void Start()
    {
        background.sprite = item.background;
        itemImg.sprite = item.itemImg;

        description.text = item.description;
        costUpgrade.text = item.costUpgrade;
    }
}
