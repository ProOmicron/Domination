using UnityEngine;
using System.Collections;

public class MainMenuButton : MonoBehaviour {

	public void ChangeScene(string sceneName) {
		Application.LoadLevel(sceneName);
	}
}
