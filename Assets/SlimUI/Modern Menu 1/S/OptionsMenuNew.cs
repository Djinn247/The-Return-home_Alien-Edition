using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

namespace SlimUI.ModernMenu{
	public class OptionsMenuNew : MonoBehaviour {

		public enum Platform {Desktop};
		public Platform platform;
	
		[Header("GAME SETTINGS")]
		public GameObject showhudtext;
		public GameObject tooltipstext;
 
		// sliders
		public GameObject musicSlider;
		public GameObject musicSliderz;
		private float sliderValue = 0.0f;
		private float sliderValuez = 0.0f; 

		public void  Start (){
 
			musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume");
			musicSliderz.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolumez");

			if (platform == Platform.Desktop){
				if(PlayerPrefs.GetInt("Shadows") == 0){
					QualitySettings.shadowCascades = 0;
					QualitySettings.shadowDistance = 0;
				 
				}
				else if(PlayerPrefs.GetInt("Shadows") == 1){
					QualitySettings.shadowCascades = 2;
					QualitySettings.shadowDistance = 75;
			 
				}
				else if(PlayerPrefs.GetInt("Shadows") == 2){
					QualitySettings.shadowCascades = 4;
					QualitySettings.shadowDistance = 500;
					 
				}
			
			}

			if(PlayerPrefs.GetInt("Textures") == 0){
				QualitySettings.masterTextureLimit = 2;
		 
			}
			else if(PlayerPrefs.GetInt("Textures") == 1){
				QualitySettings.masterTextureLimit = 1;
		 
			}
			else if(PlayerPrefs.GetInt("Textures") == 2){
				QualitySettings.masterTextureLimit = 0;
		 
			}
		}

		public void Update (){
			sliderValue = musicSlider.GetComponent<Slider>().value;
			sliderValuez = musicSliderz.GetComponent<Slider>().value;
		}

		public void FullScreen (){
			Screen.fullScreen = !Screen.fullScreen;

			if(Screen.fullScreen == true){
			//	fullscreentext.GetComponent<TMP_Text>().text = "on";
			}
			else if(Screen.fullScreen == false){
			//	fullscreentext.GetComponent<TMP_Text>().text = "off";
			}
		}

		public void MusicSlider (){
			PlayerPrefs.SetFloat("MusicVolume", sliderValue);
			PlayerPrefs.SetFloat("MusicVolume", musicSlider.GetComponent<Slider>().value);
		}

		public void MusicSliderz()
		{
			PlayerPrefs.SetFloat("MusicVolumez", sliderValuez);
			PlayerPrefs.SetFloat("MusicVolumez", musicSliderz.GetComponent<Slider>().value);
		}

		
		public void ShowHUD (){
			if(PlayerPrefs.GetInt("ShowHUD")==0){
				PlayerPrefs.SetInt("ShowHUD",1);
				showhudtext.GetComponent<TMP_Text>().text = "on";
			}
			else if(PlayerPrefs.GetInt("ShowHUD")==1){
				PlayerPrefs.SetInt("ShowHUD",0);
				showhudtext.GetComponent<TMP_Text>().text = "off";
			}
		}

		public void ToolTips (){
			if(PlayerPrefs.GetInt("ToolTips")==0){
				PlayerPrefs.SetInt("ToolTips",1);
				tooltipstext.GetComponent<TMP_Text>().text = "on";
			}
			else if(PlayerPrefs.GetInt("ToolTips")==1){
				PlayerPrefs.SetInt("ToolTips",0);
				tooltipstext.GetComponent<TMP_Text>().text = "off";
			}
		}

		 
 

		public void ShadowsOff (){
			PlayerPrefs.SetInt("Shadows",0);
			QualitySettings.shadowCascades = 0;
			QualitySettings.shadowDistance = 0;
	 
		}

		public void ShadowsLow (){
			PlayerPrefs.SetInt("Shadows",1);
			QualitySettings.shadowCascades = 2;
			QualitySettings.shadowDistance = 75;
	 
		}

		public void ShadowsHigh (){
			PlayerPrefs.SetInt("Shadows",2);
			QualitySettings.shadowCascades = 4;
			QualitySettings.shadowDistance = 500;
 
		}

	 
  

		public void vsync (){
			if(QualitySettings.vSyncCount == 0){
				QualitySettings.vSyncCount = 1;
			//	vsynctext.GetComponent<TMP_Text>().text = "on";
			}
			else if(QualitySettings.vSyncCount == 1){
				QualitySettings.vSyncCount = 0;
			//	vsynctext.GetComponent<TMP_Text>().text = "off";
			}
		}

		public void AmbientOcclusion (){
			if(PlayerPrefs.GetInt("AmbientOcclusion")==0){
				PlayerPrefs.SetInt("AmbientOcclusion",1);
			//	ambientocclusiontext.GetComponent<TMP_Text>().text = "on";
			}
			else if(PlayerPrefs.GetInt("AmbientOcclusion")==1){
				PlayerPrefs.SetInt("AmbientOcclusion",0);
			//	ambientocclusiontext.GetComponent<TMP_Text>().text = "off";
			}
		}
	
	}
}