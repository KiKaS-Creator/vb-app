using System.Runtime.CompilerServices;
using UnityEngine;

public class Wwcript : MonoBehaviour
{
    public string Eventname = "default";
    public string StopEvent = "default";
    private bool IsInCollider = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AkSoundEngine.RegisterGameObj(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" ||  IsInCollider) {return;}
        IsInCollider = true;
        AkSoundEngine.PostEvent(Eventname, gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
         if (other.tag != "Player" || !IsInCollider) {return;}
         AkSoundEngine.PostEvent(StopEvent, gameObject);
         IsInCollider = false;

    }

    private void OnTriggerStay (Collider other)
    {
        if (other.tag != "Player" || IsInCollider) {return;}
         IsInCollider = true;
         AkSoundEngine.PostEvent(Eventname, gameObject);
         
    }
    
        

}
