using UnityEngine;
using UnityEngine.Audio;

public class SettingsPanelUI : MonoBehaviour
{
  [SerializeField] private AudioMixerGroup _masterVolume;
  [SerializeField] private AudioMixerGroup _musicVolume;
  [SerializeField] private AudioMixerGroup _sFXVolume;
  [SerializeField] private GameObject _settingsPanel;

  public void ActivatePanel()
  {
    _settingsPanel.SetActive(true);
  }
  public void DisablePanel()
  {
    _settingsPanel.SetActive(false);
  }
  public void ChangeMasterVolume(float value)
  {
    _masterVolume.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, value));
  }
  public void ChangeSFXVolume(float value)
  {
    _sFXVolume.audioMixer.SetFloat("SFX", Mathf.Lerp(-80, 0, value));
  }
  public void ChangeMusicVolume(float value)
  {
    _musicVolume.audioMixer.SetFloat("Music", Mathf.Lerp(-80, 0, value));
  }

}
