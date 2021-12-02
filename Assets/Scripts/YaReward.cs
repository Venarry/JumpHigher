using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaReward : MonoBehaviour
{
    private YandexSDK SDK;


    private void Start()
    {
        SDK = YandexSDK.Instance;
        SDK.ShowCommonAdvertisment();
        SDK.Authenticate();
    }
}
