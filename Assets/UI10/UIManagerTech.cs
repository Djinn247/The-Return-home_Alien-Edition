using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class UIManagerTech : MonoBehaviour
{
	[Header("What Menu Is Active?")]
	public bool simpleMenu = false;
	public bool advancedMenu = true;

	[Header("Simple Panels")]
	[Tooltip("The UI Panel holding the Home Screen elements")]
	public GameObject homeScreen;

	[Tooltip("The UI Panel holding the settings")]
	public GameObject systemScreen;

	


	[Header("COLORS - Tint")]
	public Image[] panelGraphics;
	public Image[] blurs;
	public Color tint;


	[Tooltip("If a message is displaying indiciating FAILURE, this is the color of that error text")]
	public Color errorColor;
	[Tooltip("If a message is displaying indiciating SUCCESS, this is the color of that success text")]
	public Color successColor;
	public float messageDisplayLength = 2.0f;
	public Slider uiScaleSlider;
	float xScale = 0f;
	float yScale = 0f;

	[Header("Menu Bar")]
	public bool showMenuBar = true;
	[Tooltip("The Arrow at the corner of the screen activating and de-activating the menu bar")]
	public GameObject menuBarButton;


	[Header("Loading Screen Elements")]
	[Tooltip("The name of the scene loaded when a 'NEW GAME' is started")]
	public string newSceneName;
	[Tooltip("The loading bar Slider UI element in the Loading Screen")]
	public Slider loadingBar;
	private string loadSceneName; // scene name is defined when the load game data is retrieved

	[Header("Register Account")]
	public TMP_InputField username;
	public TMP_InputField password;
	public TMP_InputField confPassword;
	public TMP_Text error_NewAccount;
	public TMP_Text messageDisplayDatabase;
	public string newAccountMessageDisplay = "ACCOUNT CREATED";
	private string Username;
	private string Password;
	private string ConfPassword;
	private string form;
	string m_Path;
	private string[] Characters = {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
								   "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
								   "1","2","3","4","5","6","7","8","9","0","_","-"};

	[Header("Login Account")]
	public TMP_InputField logUsername;
	public TMP_InputField logPassword;
	private string logUsernameString; // the input in logUsername
	private string logPasswordString; // the input in logPassword
	private String[] Lines;
	private string DecryptedPass;
	public TMP_Text error_LogIn;
	public TMP_Text profileDisplay;
	public string loginMessageDisplay = "LOGGED IN";

	[Header("Delete Account")]
	public TMP_InputField delUsername;
	public TMP_InputField delPassword;
	private string delUsernameString; // the input in delUsername
	private string delPasswordString; // the input in delPassword
	private String[] delLines;
	private string delDecryptedPass;
	public TMP_Text error_Delete;
	public string deletedMessageDisplay = "ACCOUNT DELETED";

	[Header("Settings Screen")]
	public TMP_Text textSpeakers;
	public TMP_Text textSubtitleLanguage;
	public List<string> speakers = new List<string>();
	public List<string> subtitleLanguage = new List<string>();

	[Header("Starting Options Values")]
	public int speakersDefault = 0;
	public int subtitleLanguageDefault = 0;

	[Header("List Indexing")]
	int speakersIndex = 0;
	int subtitleLanguageIndex = 0;

	[Header("Debug")]
	[Tooltip("If this is true, pressing 'R' will reload the scene.")]
	public bool reloadSceneButton = true;
	Transform tempParent;

	public void MoveToFront(GameObject currentObj){
		//tempParent = currentObj.transform.parent;
		tempParent = currentObj.transform;
		tempParent.SetAsLastSibling();
	}

	void Start(){
		// By default, starts on the home screen, disables others
		homeScreen.SetActive(true);
		

		if(systemScreen != null)
		systemScreen.SetActive(false);
	
		
		// Set Colors if the user didn't before play
		for(int i = 0; i < panelGraphics.Length; i++)
        {
           panelGraphics[i].color = tint;
        }
	//	for(int i = 0; i < blurs.Length; i++)
      //  {
         //  blurs[i].material.SetColor("_Color",tint);
      //  }


		 
		 // Check if first time so the volume can be set to MAX
		 if(PlayerPrefs.GetInt("firsttime")==0){
			 // it's the player's first time. Set to false now...
			 PlayerPrefs.SetInt("firsttime",1);
			 PlayerPrefs.SetFloat("volume",1);
		 }



		// Settings screen
		speakersIndex = speakersDefault;
		subtitleLanguageIndex = subtitleLanguageDefault;

		textSpeakers.text = speakers[speakersDefault];
		textSubtitleLanguage.text = subtitleLanguage[subtitleLanguageDefault];
	}

	public void IncreaseIndex(int i){
		switch (i){
			case 0:
				if(speakersIndex != speakers.Count -1){speakersIndex++;}else{speakersIndex = 0;}
				textSpeakers.text = speakers[speakersIndex];
				break;
			case 1:
				if(subtitleLanguageIndex != subtitleLanguage.Count -1){subtitleLanguageIndex++;}else{subtitleLanguageIndex = 0;}
				textSubtitleLanguage.text = subtitleLanguage[subtitleLanguageIndex];
				break;
			default:
				break;
		}
	}

	public void DecreaseIndex(int i){
		switch (i){
			case 0:
				if(speakersIndex == 0){speakersIndex = speakers.Count;}speakersIndex--;
				textSpeakers.text = speakers[speakersIndex];
				break;
			case 1:
				if(subtitleLanguageIndex == 0){subtitleLanguageIndex = subtitleLanguage.Count;}subtitleLanguageIndex--;
				textSubtitleLanguage.text = subtitleLanguage[subtitleLanguageIndex];
				break;
			default:
				break;
		}
	}

	public void SetTint(){
		for(int i = 0; i < panelGraphics.Length; i++)
        {
           panelGraphics[i].color = tint;
        }
	//	for(int i = 0; i < blurs.Length; i++)
      //  {
    //   blurs[i].material.SetColor("_Color",tint);
       // }
	}

	// Just for reloading the scene! You can delete this function entirely if you want to
	void Update(){
		if(reloadSceneButton){
			if(Input.GetKeyDown(KeyCode.Delete)){
				SceneManager.LoadScene("Tech Demo Scene");
			}
		}

		SetTint();

	
	}

	// called when returned back to the database menu, confirmation message displays temporarily
	public void MessageDisplayDatabase(string message, Color col){
		StartCoroutine(MessageDisplay(message, col));
	}

	IEnumerator MessageDisplay(string message, Color col){ // Display and then clear
		messageDisplayDatabase.color = col;
		messageDisplayDatabase.text = message;
		yield return new WaitForSeconds(messageDisplayLength);
		messageDisplayDatabase.text = "";
	}



	// Make sure all the settings panel text are displaying current quality settings properly and updating UI
	
	// Converts the resolution into a string form that is then used in the dropdown list as the options
	string ResToString(Resolution res)
	{
		return res.width + " x " + res.height;
	}

	// Whenever a value on the audio slider in the settings panel is changed, this 
	// function is called and updated the overall game volume


	// When accepting the QUIT question, the application will close 
	// (Only works in Executable. Disabled in Editor)
	public void Quit(){
		Application.Quit();
	} 


	// Called when loading new game scene
	public void LoadNewLevel (){
		if(newSceneName != ""){
			StartCoroutine(LoadAsynchronously(newSceneName));
		}
	}

	// Called when loading saved scene
	// Add the save code in this function!
	public void LoadSavedLevel (){
		if(loadSceneName != ""){
			StartCoroutine(LoadAsynchronously(newSceneName)); // temporarily uses New Scene Name. Change this to 'loadSceneName' when you program the save data
		}
	}

	// Load Bar synching animation
	IEnumerator LoadAsynchronously (string sceneName){ // scene name is just the name of the current scene being loaded
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

		while (!operation.isDone){
			float progress = Mathf.Clamp01(operation.progress / .9f);
			
			loadingBar.value = progress;

			yield return null;
		}
	}





	
}
