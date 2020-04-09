using System.Collections;
using System.Collections.Generic;
using DilmerGames.Core.Singletons;
using UnityEngine;
using UnityEngine.Rendering;

public class EffectManager : Singleton<EffectManager>
{
    [SerializeField]
    private string[] effects = new string[] { "" };

    [SerializeField]
    private VolumeProfile volumeProfile;

    public void ApplyEffect(string effect)
    {
        if(effects.Length == 0)
        {
            Debug.LogError("No Effects have been setup yet");
            return;
        }

        var effectComponents = volumeProfile.components;
        foreach(var e in effectComponents)
        {
            if(e.name.Contains(effect))
            {
                e.active = true;
            }
            else
            {
                e.active = false;
            }
        }
    }
}
