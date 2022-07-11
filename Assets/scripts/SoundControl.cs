using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    public Sprite MusicEnabled, MusicDisabled;
    public Image ButtonImage;
    private AudioSource[] _audioSources;

    private void MuteAllAs(bool isMuted = true)
    {
        foreach (var a in _audioSources)
        {
            a.mute = isMuted;
        }
    }

    public void ToggleMusic()
    {
        if (_audioSources[0].mute == false)
        {
            ButtonImage.sprite = MusicDisabled;
            MuteAllAs();
        }
        else
        {
            MuteAllAs(false);
            ButtonImage.sprite = MusicEnabled;
        }
        PlayerPrefs.SetInt("music", _audioSources[0].mute ? 1 : 0);
    }

    void Awake()
    {
        _audioSources = FindObjectsOfType<AudioSource>();
        var isMuted = PlayerPrefs.GetInt("music", 0) == 1 ? true : false;
        MuteAllAs(isMuted);
        ButtonImage.sprite = isMuted ? MusicDisabled : MusicEnabled;
    }
}