using UnityEngine;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
     public AudioSource musicSouce;
     public AudioSource jump;
     public AudioSource fall;
     public AudioSource platformPlace;

     
     public static AudioManager Instance = null;
     
     private bool hasFallen = false;

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

       public void PlaySound_Jump()
       {
           jump.Play();
       }
       
       public void PlaySound_Fall()
       {
           if (!fall.isPlaying && hasFallen == false)
           {
               fall.Play();
               hasFallen = true;
           }
       }
       
       public void PlaySound_PlatformPlace()
       {
           platformPlace.Play();
           hasFallen = true;
       }
}
