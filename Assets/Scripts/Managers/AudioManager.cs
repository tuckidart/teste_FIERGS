using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Variables

    public static AudioManager Instance { get; private set; } = null;

    [SerializeField]
    private AudioSource _musicAudioSource = null;
    [SerializeField]
    private AudioSource _sfxAudioSource = null;

    [Space]

    [SerializeField]
    private AudioClip _mainMenuMusic = null;
    [SerializeField]
    private AudioClip _battleMusic = null;

    [Space]

    [SerializeField]
    private AudioClip _damageSfx = null;
    [SerializeField]
    private AudioClip _healSfx = null;
    [SerializeField]
    private AudioClip _armorSfx = null;
    [SerializeField]
    private AudioClip _cardHover = null;
    [SerializeField]
    private AudioClip _cardSelect = null;
    [SerializeField]
    private AudioClip _endTurn = null;
    [SerializeField]
    private AudioClip _click = null;
    [SerializeField]
    private AudioClip _error = null;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = this;
    }

    #endregion

    #region Music Methods

    public void PlayMainMenuMusic()
    {
        _musicAudioSource.clip = _mainMenuMusic;
        PlayMusic();
    }

    public void PlayBattleMusic()
    {
        if (_musicAudioSource.clip == _battleMusic)
            return;

        _musicAudioSource.clip = _battleMusic;
        PlayMusic();
    }

    private void PlayMusic()
    {
        _musicAudioSource.Play();
    }

    #endregion

    #region Sfx Methods

    public void PlayDamage()
    {
        _sfxAudioSource.clip = _damageSfx;
        PlaySound();
    }

    public void PlayHeal()
    {
        _sfxAudioSource.clip = _healSfx;
        PlaySound();
    }

    public void PlayArmor()
    {
        _sfxAudioSource.clip = _armorSfx;
        PlaySound();
    }

    public void PlayCardHover()
    {
        _sfxAudioSource.clip = _cardHover;
        PlaySound();
    }

    public void PlayCardSelect()
    {
        _sfxAudioSource.clip = _cardSelect;
        PlaySound();
    }

    public void PlayEndTurn()
    {
        _sfxAudioSource.clip = _endTurn;
        PlaySound();
    }

    public void PlayClick()
    {
        _sfxAudioSource.clip = _click;
        PlaySound();
    }

    public void PlayError()
    {
        _sfxAudioSource.clip = _error;
        PlaySound();
    }

    private void PlaySound()
    {
        _sfxAudioSource.Play();
    }

    #endregion
}
