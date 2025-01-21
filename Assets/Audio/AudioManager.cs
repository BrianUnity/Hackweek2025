using UnityEngine;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
     public AudioSource musicSouce;
     public AudioSource jump;
   
     public static AudioManager Instance = null;

     // Initialize the singleton instance.
     private void Awake()
     {
         // If there is not already an instance of SoundManager, set it to this.
         if (Instance == null)
         {
             Instance = this;
         }
         //If an instance already exists, destroy whatever this object is to enforce the singleton.
         else if (Instance != this)
         {
             Destroy(gameObject);
         }

         //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
         DontDestroyOnLoad (gameObject);
     }
       void Start()
       {
           musicSouce.Play();
       }

       public void PlayJumpSound()
       {
           jump.Play();
       }
}
