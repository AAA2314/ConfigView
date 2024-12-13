using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Title);
        //SoundManager.Instance.PlayBGM(BGMSoundData.BGM.リストタグ);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
