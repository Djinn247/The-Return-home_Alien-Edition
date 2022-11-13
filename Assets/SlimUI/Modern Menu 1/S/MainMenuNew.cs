using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace SlimUI.ModernMenu{
	public class MainMenuNew : MonoBehaviour {
		Animator CameraObject;

		[Header("Loaded Scene")]
		[Tooltip("The name of the scene in the build settings that will load")]
		public string sceneName = ""; 

		public enum Theme {custom1, custom2, custom3};
		[Header("Theme Settings")]
		public Theme theme;
		int themeIndex;
		public FlexibleUIData themeController;

		[Header("Panels")]
		[Tooltip("The UI Panel parenting all sub menus")]
		public GameObject mainCanvas;
		[Tooltip("The UI Panel that holds the CONTROLS window tab")]
		public GameObject PanelControls;
		[Tooltip("The UI Panel that holds the VIDEO window tab")]
	
		public GameObject PanelGame;
		[Tooltip("The UI Panel that holds the KEY BINDINGS window tab")]


		[Header("SFX")]
		public AudioSource hoverSound;
		[Tooltip("The GameObject holding the Audio Source component for the AUDIO SLIDER")]
		public AudioSource sliderSound;
		[Tooltip("The GameObject holding the Audio Source component for the SWOOSH SOUND when switching to the Settings Screen")]
		public AudioSource swooshSound;
		[Tooltip("The GameObject holding the Audio Source component for the Music")]
		public AudioSource Music;

		[Header("Menus")]
		[Tooltip("The Menu for when the MAIN menu buttons")]
		public GameObject mainMenu;
		[Tooltip("THe first list of buttons")]
		public GameObject firstMenu;
		[Tooltip("The Menu for when the PLAY button is clicked")]
		public GameObject playMenu;
		[Tooltip("The Menu for when the EXIT button is clicked")]
		public GameObject exitMenu;
	

		[Header("LOADING SCREEN")]
		public GameObject loadingMenu;
		public Slider loadBar;
		public TMP_Text finishedLoadingText;
		public bool requireInputForNextScene = false;

		void Start(){
			CameraObject = transform.GetComponent<Animator>();
			playMenu.SetActive(false);
			exitMenu.SetActive(false);
			firstMenu.SetActive(true);
			mainMenu.SetActive(true);

			SetThemeColors();
		}

		void SetThemeColors(){
			if(theme == Theme.custom1){
				themeController.currentColor = themeController.custom1.graphic1;
				themeController.textColor = themeController.custom1.text1;
				themeIndex = 0;
			}else if(theme == Theme.custom2){
				themeController.currentColor = themeController.custom2.graphic2;
				themeController.textColor = themeController.custom2.text2;
				themeIndex = 1;
			}else if(theme == Theme.custom3){
				themeController.currentColor = themeController.custom3.graphic3;
				themeController.textColor = themeController.custom3.text3;
				themeIndex = 2;
			}
		}

		public void PlayCampaign(){
			exitMenu.SetActive(false);
			playMenu.SetActive(true);
		}
		
		public void PlayCampaignMobile(){
			exitMenu.SetActive(false);
			playMenu.SetActive(true);
			mainMenu.SetActive(false);
		}

		public void ReturnMenu(){
			playMenu.SetActive(false);
			exitMenu.SetActive(false);
			mainMenu.SetActive(true);
		}

		public void NewGame(){
			if(sceneName != ""){
				StartCoroutine(LoadAsynchronously(sceneName));
			}
		}

		public void  DisablePlayCampaign(){
			playMenu.SetActive(false);
		}

		public void Position2(){
			DisablePlayCampaign();
			CameraObject.SetFloat("Animate",1);
		}

		public void Position1(){
			CameraObject.SetFloat("Animate",0);
		}

		void DisablePanels(){
			PanelControls.SetActive(false);
			PanelGame.SetActive(false);
		}
		public void GamePanel(){
			DisablePanels();
			PanelGame.SetActive(true);
		}
		public void ControlsPanel(){
			DisablePanels();
			PanelControls.SetActive(true);
		}
		public void KeyBindingsPanel(){
			DisablePanels();
			MovementPanel();
		}

		public void MovementPanel(){
			DisablePanels();
		}
		public void CombatPanel(){
			DisablePanels();
		}
		public void GeneralPanel(){
			DisablePanels();
		}
		public void PlayHover(){
			hoverSound.Play();
		}
		public void PlaySFXHover(){
			sliderSound.Play();
		}
		public void PlaySwoosh(){
			swooshSound.Play();
		}
		public void PlayMusic()
		{
			Music.Play();
		}

		public void AreYouSure(){
			exitMenu.SetActive(true);
			DisablePlayCampaign();
		}
		public void QuitGame(){
			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
			#else
				Application.Quit();
			#endif
		}

		IEnumerator LoadAsynchronously(string sceneName){
			AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
			operation.allowSceneActivation = false;
			mainCanvas.SetActive(false);
			loadingMenu.SetActive(true);

			while (!operation.isDone){
				float progress = Mathf.Clamp01(operation.progress / .9f);
				loadBar.value = progress;

				if(operation.progress >= 0.9f){
					if(requireInputForNextScene){
						finishedLoadingText.gameObject.SetActive(true);

						if(Input.anyKeyDown){
							operation.allowSceneActivation = true;
						}
					}else{
						operation.allowSceneActivation = true;
					}
				}
				
				yield return null;
			}
		}
	}
}