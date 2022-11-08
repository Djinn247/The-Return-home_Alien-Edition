using UnityEngine;
using UnityEngine.SceneManagement;

namespace SlimUI.ModernMenu{
	public class ResetDemo : MonoBehaviour {

		void Update () {
			if(Input.GetKeyDown("s")){
				SceneManager.LoadScene(1);
			}
		}
	}
}