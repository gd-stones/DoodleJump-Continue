using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action ScalePlatfs;
    public static event Action DescalePlatfs;

    public static event Action ActivateShield;
    public static event Action DeactivateShield;

    public static event Action ActivateSword;
    public static event Action DeactivateSword;

    public static event Action<float> OnCamMove;
    public static event Action<Transform> CreateItem;
    public static event Action<Transform> CreateEnemy;

    public static void ScalePlatforms() => ScalePlatfs?.Invoke();
    public static void DescalePlatforms() => DescalePlatfs?.Invoke();

    public static void EnableShieldFeature() => ActivateShield?.Invoke();
    public static void DisableShieldFeature() => DeactivateShield?.Invoke();

    public static void EnableSwordFeature() => ActivateSword?.Invoke();
    public static void DisableSwordFeature() => DeactivateSword?.Invoke();

    public static void OnCameraMove(float distance) => OnCamMove?.Invoke(distance);

    public static void SpawnItem(Transform platf) => CreateItem?.Invoke(platf);

    public static void SpawnEnemy(Transform platf) => CreateEnemy?.Invoke(platf);
}
