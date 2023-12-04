using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardSO : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite artwork;

    public string cost;

    public int manaCost;
    public int attack;
    public int health;
    public int damage;

    public void Print()
    {
        Debug.Log(name + ": " + description);
    }
}
