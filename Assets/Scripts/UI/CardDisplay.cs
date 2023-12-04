using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public CardSO card;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI priceText;

    public Image artworkImage;

    private void Start()
    {
        nameText.text = card.name;
        descriptionText.text = card.description;
        priceText.text = card.cost;

        artworkImage.sprite = card.artwork;
    }
}