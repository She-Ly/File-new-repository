using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotTierra : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public Seed seed;
    public Key key;
    public PlantaSetUpRoom planta;
    public GameObject seedUI;
    public GameObject keyUI;

    public GameObject inventarioSelect;
    public GameObject newSlot;
    public GameObject oldSlot;

    public GameObject continueButton;
    public GameObject optionsButton;

    public Dialogue firstDialogue;
    public Dialogue secondDialogue;
    public Dialogue thirdDialogue;
    public Dialogue fourthDialogue;
    public Dialogue fifthDialogue;

    private bool isDialogueInProgress = false;
    public GameObject interactionPromptUI;
    public AudioClip sembrar;


    public bool Interact(Interactor interactor)
    {
        if (isDialogueInProgress)
        {
            return false;
        }

        interactionPromptUI.SetActive(false);

        bool hasDifferentInteractions = CheckForDifferentInteractions(firstDialogue);


        continueButton.SetActive(!hasDifferentInteractions);
        optionsButton.SetActive(hasDifferentInteractions);

        StartCoroutine(TriggerAndHandleDialogue(firstDialogue));

        return true;
    }
   
        //si dar agua set active sprite mas viva activar sketch planta2d activar sexto dialogo has cultivado !! cuando se planta la ya uedes encontrar la llave? also la llave debe llevar un sketch xd

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private IEnumerator TriggerAndHandleDialogue(Dialogue dialogue)
    {
        isDialogueInProgress = true;

        TriggerDialogue(dialogue);
        while (FindObjectOfType<DialogueManager>().IsDialogueActive)
        {
            yield return null;
        }
        interactionPromptUI.SetActive(true);
        isDialogueInProgress = false;
    }

    private bool CheckForDifferentInteractions(Dialogue dialogue)
    {
        for (int i = 0; i < dialogue.sentences.Length; i++)
        {
            if (dialogue.hasDifferentInteractions[i])
            {
                return true;
            }
        }
        return false;
    }

    public void Plantar()
    {
        if (planta.hasPlantavida == false)
        {
            EsconderOpciones();
            StartCoroutine(TriggerAndHandleDialogue(secondDialogue));
            AudioManager.instance.PlaySoundEffect(sembrar);
        }

        else
        {
            ShowInventory();
            StartCoroutine(TriggerAndHandleDialogue(thirdDialogue)); //que quieres plantar aqui?
            continueButton.SetActive(false);
            AudioManager.instance.PlaySoundEffect(sembrar);
        }
    }

    public void EsconderOpciones()
    { //Destroy(GameObject) en vez de esconder
        continueButton.SetActive(true);
        optionsButton.SetActive(false);
    }

    public void PlantarPlantavida()
    {
        continueButton.SetActive(true);
        StartCoroutine(TriggerAndHandleDialogue(fourthDialogue)); //has plantado una plantavida, pero se ve algo triste, nota, hacer script de cuidar planta
        newSlot.SetActive(true);
        oldSlot.SetActive(false);
        HideInventory();
        planta.plantaUI.SetActive(false);
        //aqui hacer que aparezca la nota para tener la llave solo despues de plantar la planta ig

    }

    public void PlantarPlantula()
    {
        continueButton.SetActive(false);
        StartCoroutine(TriggerAndHandleDialogue(fifthDialogue)); //esto no se puede plantar, que quieres plantar?
    }

    public void ShowInventory()
    {
        inventarioSelect.SetActive(true);
        if (seed.hasSeed1 == true)
        {
            seedUI.SetActive(true);
        }
        if (key.hasKey == true)
        {
            keyUI.SetActive(true);
        }
    }

    public void HideInventory()
    {
        inventarioSelect.SetActive(false);
        keyUI.SetActive(false);
        seedUI.SetActive(false);

    }

}
