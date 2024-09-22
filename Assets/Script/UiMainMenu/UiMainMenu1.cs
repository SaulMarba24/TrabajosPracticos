using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiMainMenu : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button settingsButton;  // Botón para ingresar al menú de configuración
    [SerializeField] private Button creditsButton;  // Botón para ingresar al menú de créditos
    [SerializeField] private Button backButtonSettings;  // Botón para regresar del menú de configuración
    [SerializeField] private Button backButtonCredits;  // Botón para regresar del menú de créditos

    [Header("Main Menu")]
    [SerializeField] private GameObject mainMenuPanel;  // Panel del menú principal
    [SerializeField] private GameObject settingsPanel;  // Panel del menú de configuración
    [SerializeField] private GameObject creditsPanel;  // Panel del menú de créditos

    [Header("Settings")]// Tengo que corregir para que funcionen

    [SerializeField] private Slider player1SpeedSlider;
    [SerializeField] private Text player1SpeedText;
    [SerializeField] private Slider player2SpeedSlider;
    [SerializeField] private Text player2SpeedText;

    [SerializeField] private Movement player1;
    [SerializeField] private Movement player2;

    private bool isMainMenuActive = false;  // Variable para rastrear el estado del menú principal

    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);  // Vincula el botón "Settings"
        creditsButton.onClick.AddListener(OnCreditsButtonClicked);  // Vincula el botón "Credits"
        backButtonSettings.onClick.AddListener(OnBackFromSettingsClicked);  // Vincula el botón "Back" del menú de configuración
        backButtonCredits.onClick.AddListener(OnBackFromCreditsClicked);  // Vincula el botón "Back" del menú de créditos

        player1SpeedSlider.onValueChanged.AddListener(OnPlayer1SpeedSliderChanged);
        player2SpeedSlider.onValueChanged.AddListener(OnPlayer2SpeedSliderChanged);
    }

    private void Start()
    {
        // Inicializar los sliders con la velocidad actual de los jugadores
        player1SpeedSlider.value = player1.GetMovementSpeed();
        player2SpeedSlider.value = player2.GetMovementSpeed();
        
        mainMenuPanel.SetActive(false);  // Inicialmente, el menú principal está oculto
        settingsPanel.SetActive(false);  // El menú de configuración también está oculto
        creditsPanel.SetActive(false);  // El menú de créditos también está oculto
    }

    private void Update()
    {
        // Detectar cuando se presiona la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMainMenu();
        }
    }

    private void ToggleMainMenu()
    {
        isMainMenuActive = !isMainMenuActive;  // Alternar el estado del menú principal

        mainMenuPanel.SetActive(isMainMenuActive);
        settingsPanel.SetActive(false);  // Asegurarse de que el panel de configuración esté oculto al mostrar el menú principal
        creditsPanel.SetActive(false);  // Asegurarse de que el panel de créditos esté oculto al mostrar el menú principal
    }

    private void OnPlayButtonClicked()
    {
        isMainMenuActive = false;
        mainMenuPanel.SetActive(false);  // Oculta el menú principal al iniciar el juego
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif    
    }

    private void OnSettingsButtonClicked()
    {
        mainMenuPanel.SetActive(false);  // Oculta el menú principal
        settingsPanel.SetActive(true);   // Muestra el panel de configuración
    }

    private void OnCreditsButtonClicked()
    {
        mainMenuPanel.SetActive(false);  // Oculta el menú principal
        creditsPanel.SetActive(true);   // Muestra el panel de créditos
    }

    private void OnBackFromSettingsClicked()
    {
        settingsPanel.SetActive(false);  // Oculta el panel de configuración
        mainMenuPanel.SetActive(true);   // Muestra el menú principal
    }

    private void OnBackFromCreditsClicked()
    {
        creditsPanel.SetActive(false);  // Oculta el panel de créditos
        mainMenuPanel.SetActive(true);   // Muestra el menú principal
    }

    private void OnPlayer1SpeedSliderChanged(float value)
    {
        player1.SetMovementSpeed(value);
        player1SpeedText.text = $"Player 1 Speed: {value:F2}";
    }

    private void OnPlayer2SpeedSliderChanged(float value)
    {
        player2.SetMovementSpeed(value);
        player2SpeedText.text = $"Player 2 Speed: {value:F2}";
    }
}
