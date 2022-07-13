using System.Collections;
using System.Collections.Generic;
using SonaruUtilities;
using UnityEngine;

public class AudioController : TSingletonMonoBehaviour<AudioController>
{
    //public GameObject sfxItemSpawn;
    public List<AudioData> AllSFX;

    private Dictionary<SFXType, AudioClip> SFXDict;

    protected override void Awake()
    {
        base.Awake();
        SFXDict = new Dictionary<SFXType, AudioClip>();
        foreach (var sfx in AllSFX)
        {
            SFXDict[sfx.SfxType] = sfx.Clip;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnSFX(SFXType sfx)
    {
        var sfxItem = new GameObject("sfxItem");
        sfxItem.transform.parent = transform;
        var audioSource = sfxItem.AddComponent<AudioSource>();
        audioSource.PlayOneShot(SFXDict[sfx]);
        StartCoroutine(DestroySelf(SFXDict[sfx], sfxItem));
    }

    public IEnumerator DestroySelf(AudioClip clip, GameObject sfxObj)
    {
        yield return new WaitForSeconds(clip.length);
        Destroy(sfxObj);
    }
}

[System.Serializable]
public class AudioData
{
    public SFXType SfxType;
    public AudioClip Clip;
}