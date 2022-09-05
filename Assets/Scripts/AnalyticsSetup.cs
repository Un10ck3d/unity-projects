using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using System.Collections.Generic;

public class AnalyticsSetup : MonoBehaviour
{
    async void Start()
    {
        try {
            await UnityServices.InitializeAsync();
            List<string> consentIdentifiers = await AnalyticsService.Instance.CheckForRequiredConsents();
        } catch (UnityException e) {
            Debug.Log("ERROR!");
            Debug.Log(e);
        }
    }
}
