using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    [SerializeField] private List<Unit> _units;
    [SerializeField] private Material _redMaterial, _blueMaterial;

    public object Faction { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    //public void SelectColor(string color)
    //{
    //    //var heros = _units.Where(u => u.Faction == Faction.Player);
    //    foreach (var hero in heros)
    //    {
    //        hero.ChangeMaterial(color == "red" ? _redMaterial : _blueMaterial);
    //    }

    //    GameManagerX.Instance.UpdateGameState(GameStateX.PlayerTurn);
    //}

    //public async void Attack(Faction faction)
    //{

    //}

    //internal void Attack(object enemy)
    //{

    //}
}
