using UnityEngine;

public class SoundAssets : MonoBehaviour
{
	//In order to make a prefab with this class, it is required to create a Resources folder
	//as a subfolder of the main assets folder, then create an empty gameobject to which
	//you add this script. After that, assign an audio clip to each value of the sound enum
	//that can be found in the SoundManager class. 

	//singleton instance
	private static SoundAssets _i;

	public static SoundAssets instance
	{
		get
		{
			if (_i == null) _i = (Instantiate(Resources.Load("SoundAssets")) as GameObject).GetComponent<SoundAssets>();
			return _i;
		}
	}

	public static float sfxVolume = 0.5f;

	//the array where you can assign audio clips for the sounds
	public SoundAudioClip[] soundAudioClipArray;

	//Serializing this so it can be easily edited in Unity
	[System.Serializable]
	public class SoundAudioClip
	{
		public SoundManager.Sound sound;
		public AudioClip audioClip;
		public float volume = 0.5f;
	}
}
