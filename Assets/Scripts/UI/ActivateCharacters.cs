using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActivateCharacters : MonoBehaviour
{
    public Button[] purchaseButtons;
    public TextMeshProUGUI[] goldTexts;

    public Button[] activateButtons;
    public Image[] backgrounds;

    private Color defaultColor = new Color(1, 1, 1, 0.4f);
    private Color activateColor = new Color(0.8f, 0.1f, 1, 0.4f);

    private void Awake()
    {
        for (int i = 0; i < purchaseButtons.Length; i++)
        {
            int index = i;
            purchaseButtons[i].onClick.AddListener(() => PurchaseCharacter(index));

            activateButtons[i].onClick.AddListener(() => ActivateCharacter(index));
            activateButtons[i].interactable = false;
        }
    }
    
    private void PurchaseCharacter(int index)
    {
        activateButtons[index].interactable = true;
        purchaseButtons[index].interactable = false;
        goldTexts[index].text = "Purchased";
    }

    private void ActivateCharacter(int index)
    {
        foreach (Image background in backgrounds)
            background.color = defaultColor;

        backgrounds[index].color = activateColor;
    }
}