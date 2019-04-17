// CustomAudioClipLoader
using Fabric;
using System.Collections;
using UnityEngine;

public abstract class CustomAudioClipLoader : MonoBehaviour
{
	public AudioClip _audioClip;

	public abstract IEnumerator LoadAudioClip(string audioClipName, LanguageProperties language);
}
