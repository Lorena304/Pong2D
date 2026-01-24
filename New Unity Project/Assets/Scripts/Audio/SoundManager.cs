using UnityEngine;

public static class SoundManager
{
	//here you define all the available sound effects
	//audio clips should be assigned to these in the SoundAssets class
	public enum Sound
	{
		None,
		ButtonClick,
		Score,
		Collision
	}

	//this is the most simple function for playing sound effects _ basically in 2D 
	public static void PlaySound(Sound pSound, float volume = -1)
	{
		//when none is selected, nothing is played
		if (pSound == Sound.None)
		{
			return;
		}

		//creating the gameobject that will play the sound effect
		GameObject soundGameObject = new GameObject("Sound");
		AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();

		//getting the audio clip from the game assets
		audioSource.clip = GetAudioClip(pSound);

		float finalVolume = volume == -1 ? GetAudioVolume(pSound) : volume;

		//audio settings for the sound effect
		audioSource.volume = finalVolume * SoundAssets.sfxVolume;

		//playing the sound effect once
		audioSource.PlayOneShot(audioSource.clip);

		//destroying the gameobject once the sound effect is done playing
		Object.Destroy(soundGameObject, audioSource.clip.length);
	}

	//this function allows the playing of a sound from a certain position in 3D
	public static void PlaySound(Sound pSound, Vector3 pPosition)
	{
		//when none is selected, nothing is played
		if (pSound == Sound.None)
		{
			return;
		}

		//creating the gameobject that will play the sound effect, and applying its position
		GameObject soundGameObject = new GameObject("Sound 3D");
		soundGameObject.transform.position = pPosition;
		AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();

		//getting the audio clip from the game assets
		audioSource.clip = GetAudioClip(pSound);

		//audio settings for the sound effect
		audioSource.volume = GetAudioVolume(pSound) * SoundAssets.sfxVolume;
		audioSource.maxDistance = 100f;
		audioSource.spatialBlend = 1f;
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.dopplerLevel = 0f;

		//playing the sound effect
		audioSource.Play();

		//destroying the gameobject once the sound effect is done playing
		Object.Destroy(soundGameObject, audioSource.clip.length);
	}


	public static void PlaySound(AudioClip pAudioClip, float volume = 0.5f)
	{
		if (pAudioClip == null)
		{
			Debug.Log("Missing audioclip from an object");
			return;
		}

		//creating the gameobject that will play the sound effect
		GameObject soundGameObject = new GameObject("Sound");
		AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();

		//getting the audio clip from the game assets
		audioSource.clip = pAudioClip;

		//audio settings for the sound effect
		audioSource.volume = volume * SoundAssets.sfxVolume;

		//playing the sound effect once
		audioSource.PlayOneShot(audioSource.clip);

		//destroying the gameobject once the sound effect is done playing
		Object.Destroy(soundGameObject, audioSource.clip.length);
	}

	private static AudioClip GetAudioClip(Sound pSound)
	{
		//searching for the sound effects in the game assets
		foreach (SoundAssets.SoundAudioClip soundAudioClip in SoundAssets.instance.soundAudioClipArray)
		{
			if (soundAudioClip.sound == pSound)
			{
				if (soundAudioClip.audioClip != null)
				{
					return soundAudioClip.audioClip;
				}
				else
				{
					Debug.LogError("Audio clip for sound " + pSound + " not found");
					return null;
				}
			}
		}
		//in case it doesn't find it, show it in the console
		Debug.LogError("Sound " + pSound + " not found");
		return null;
	}

	private static float GetAudioVolume(Sound pSound)
	{
		//searching for the sound effects in the game assets
		foreach (SoundAssets.SoundAudioClip soundAudioClip in SoundAssets.instance.soundAudioClipArray)
		{
			if (soundAudioClip.sound == pSound)
			{
				return soundAudioClip.volume;
			}
		}
		//in case it doesn't find it, show it in the console
		Debug.LogError("Sound " + pSound + " not found");
		return 0.5f;
	}
}
