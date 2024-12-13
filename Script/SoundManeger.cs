using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    [SerializeField] public AudioSource bgmAudioSource;
    [SerializeField] AudioSource seAudioSource;

    [SerializeField] List<BGMSoundData> bgmSoundDatas;
    [SerializeField] List<SESoundData> seSoundDatas;
    [SerializeField] Slider BgmSlider;
    [SerializeField] Slider SeSlider;
    [SerializeField] Slider MasterSlider;
    [SerializeField] Text bgmValue;
    [SerializeField] Text seValue;
    [SerializeField] Text masterValue;
    static public float masterVolume = 0.5f;
    static public float bgmMasterVolume = 0.5f;
    static public float seMasterVolume = 0.5f;
    float bgm;
    float se;
    float master;
    public static SoundManager Instance { get; private set; }

    private void Start()
    {
        // スライダーの初期値を設定
        BgmSlider.value = bgmMasterVolume;
        SeSlider.value = seMasterVolume;
        MasterSlider.value = masterVolume;

        // 初期値をテキストに反映
        bgmValue.text = Mathf.FloorToInt(BgmSlider.value * 100).ToString();
        seValue.text = Mathf.FloorToInt(SeSlider.value * 100).ToString();
        masterValue.text = Mathf.FloorToInt(MasterSlider.value * 100).ToString();
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = bgmSoundDatas.Find(data => data.bgm == bgm);
        bgmAudioSource.clip = data.audioClip;
        bgmAudioSource.volume = data.volume * bgmMasterVolume * masterVolume;
        bgmAudioSource.Play();
    }


    public void PlaySE(SESoundData.SE se)
    {
        SESoundData data = seSoundDatas.Find(data => data.se == se);
        seAudioSource.volume = data.volume * seMasterVolume * masterVolume;
        seAudioSource.PlayOneShot(data.audioClip);
    }

    public void OnChangeBgmSlider()
    {
        bgmMasterVolume = BgmSlider.value;
        bgm = Mathf.FloorToInt(BgmSlider.value * 100);
        bgmValue.text = bgm.ToString();

        // BGM の音量に即座に反映
        if (bgmAudioSource.isPlaying)
        {
            bgmAudioSource.volume = bgmMasterVolume * masterVolume;
        }
    }
    public void OnChangeSeSlider()
    {
        seMasterVolume = SeSlider.value;
        se = Mathf.FloorToInt(SeSlider.value * 100);
        seValue.text = se.ToString();
    }
    public void OnChangeMasterSlider()
    {
        masterVolume = MasterSlider.value;
        master = Mathf.FloorToInt(MasterSlider.value * 100);
        masterValue.text = master.ToString();

        // BGM の音量に即座に反映
        if (bgmAudioSource.isPlaying)
        {
            bgmAudioSource.volume = bgmMasterVolume * masterVolume;
        }
    }
}

[System.Serializable]
public class BGMSoundData
{
    public enum BGM
    {
        Title,
        Dungeon,
        Hoge, // これがラベルになる
    }

    public BGM bgm;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}

[System.Serializable]
public class SESoundData
{
    public enum SE
    {
        Attack,
        Damage,
        Hoge, // これがラベルになる
    }

    public SE se;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;

}