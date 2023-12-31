using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class MainMenu : MonoBehaviour
{
	private UIDocument _document;

	private void Awake()
	{
		_document = GetComponent<UIDocument>();

		var root = _document.rootVisualElement;
		root.Q<Button>("button-play").clicked += OnClickedButtonPlay;
		root.Q<Button>("button-settings").clicked += OnClickedButtonSettings;
		root.Q<Button>("button-exit").clicked += OnClickedButtonExit;

		SceneManager.sceneUnloaded += OnSceneUnloaded;
	}

	private void OnDestroy()
	{
		SceneManager.sceneUnloaded -= OnSceneUnloaded;
	}

	private void OnClickedButtonPlay()
	{
		GameScene.LoadScene(GameScene.Id.LevelSelection);
	}

	private void OnClickedButtonSettings()
	{
		_document.rootVisualElement.style.display = DisplayStyle.None;
		GameScene.LoadScene(GameScene.Id.Settings, LoadSceneMode.Additive);
	}

	private void OnClickedButtonExit()
	{
		Application.Quit();
	}

	private void OnSceneUnloaded(Scene unloadedScene)
	{
		var display = unloadedScene.buildIndex == (int)GameScene.Id.Settings ? DisplayStyle.Flex : DisplayStyle.None;
		_document.rootVisualElement.style.display = display;
	}
}