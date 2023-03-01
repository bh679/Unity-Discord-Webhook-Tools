using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BrennanHatton.Discord
{
	public class SceneNameToDiscordLog : MonoBehaviour
    {
	    void OnEnable()
	    {
		    DiscordLogManager.Instance.AddToStringAtEnd(GetSceneName);
	    }
	    
	    public string GetSceneName()
	    {
	    	return SceneManager.GetActiveScene().name;
	    }
    }
}
