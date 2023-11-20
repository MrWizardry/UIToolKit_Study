using System;
using UnityEngine;
using UnityEngine.UIElements;

public class IGUI : MonoBehaviour
{
    private UIToolKitSc uIToolKitSc;
    public VisualElement IGUIElement;
    public VisualElement Inventory;
    public VisualElement PauseElement;

    public Button Pause;
    public Button Resume;
    public Button VoltarMenu;

    private bool inventoryActive = false;
    private float cooldown = 0.5f;
    private float nextPressTime = 0f;

    void Start(){
        uIToolKitSc = GetComponent<UIToolKitSc>();
        var root = GetComponent<UIDocument>().rootVisualElement;

        IGUIElement = root.Q<VisualElement>("IGUIElement");
        Inventory = root.Q<VisualElement>("Inventory");
        PauseElement = root.Q<VisualElement>("PauseElement");

        Pause = root.Q<Button>("Pause");
        Resume = root.Q<Button>("Resume");
        VoltarMenu = root.Q<Button>("VoltarMenu");

        Pause.clicked += PauseButtonClicked;
        Resume.clicked += ResumeButtonClicked;
        VoltarMenu.clicked += VoltarMenuButtonClicked;
    }

    void PauseButtonClicked()
    {
        PauseElement.style.display = DisplayStyle.Flex;
    }
    void ResumeButtonClicked ()
    {
        PauseElement.style.display = DisplayStyle.None;
    }
    void VoltarMenuButtonClicked()
    {
        PauseElement.style.display = DisplayStyle.None;
        IGUIElement.style.display = DisplayStyle.None;
        uIToolKitSc.menuElement.style.display = DisplayStyle.Flex;
    }

    void Update()
    {
        if (Time.time >= nextPressTime)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Atualizar o próximo momento em que a tecla pode ser pressionada
                nextPressTime = Time.time + cooldown;

                // Alternar o estado do inventário
                if (inventoryActive)
                {
                    // Desativar o inventário
                    Inventory.style.display = DisplayStyle.None;
                }
                else
                {
                    // Ativar o inventário
                    Inventory.style.display = DisplayStyle.Flex;
                }

                // Alternar o estado da variável
                inventoryActive = !inventoryActive;
            }
        }
    }
}
