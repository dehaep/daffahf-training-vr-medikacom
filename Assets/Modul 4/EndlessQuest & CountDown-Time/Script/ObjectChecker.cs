using Tproject.Quest;
using UnityEngine;
using Module4;
using Seville;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using System.Collections;

public class ObjectChecker : MonoBehaviour
{
    public Module4.QuestController questController;
    public ObjectValidatorManager objectValidatorManager;
    public ObjectValidator[] objectValidators;


    public GameObject popUpRight;
    public GameObject popUpWrong;


    public void ValidateSockets()
    {
        bool allSocketsOccupied = true;
        foreach (ObjectValidator validator in objectValidators)
        {
            if (!validator.socketOccupied)
            {
                allSocketsOccupied = false;
                break;
            }
        }

        // If all sockets are occupied, validate the items
        if (allSocketsOccupied)
        {
            if (objectValidatorManager.AreAllItemsValid(objectValidators))
            {
                //add score here
                //reset and finish quest here
                StartCoroutine(showPopup(popUpRight));
                FinishAllTask();
            }
            else
            {
                StartCoroutine(showPopup(popUpWrong));
                TaskFailed();
            }
        }
    }

    private void FinishAllTask()
    {
        for (int i = 0; i < objectValidators.Length; i++)
        {
            questController.FinishItem(i);
        }
        questController.toDoList.Clear();
        objectValidatorManager.ClearSelectedItemTypes();
        ResetItemPosition();

    }

    public void TaskFailed()
    {
        for (int i = 0; i < objectValidators.Length; i++)
        {
            questController.FinishItem(i);
        }
        questController.toDoList.Clear();
        objectValidatorManager.ClearSelectedItemTypes();
        ResetItemPosition();
    }

    public void ResetItemPosition()
    {
        foreach (ObjectValidator validator in objectValidators)
        {
            SESocketInteractor interactor = validator.GetComponent<SESocketInteractor>();
            IXRSelectInteractable interactable = interactor.selectTarget;
            ItemData itemData = interactable != null ? interactable.transform.GetComponent<ItemData>() : null;
            if (itemData != null)
            {
                interactor.enabled = false;
                itemData.ResetPosition();
                interactor.enabled = true;
                validator.GetComponent<MeshRenderer>().enabled = true;
            }
        }

        questController.toDoList.Clear();
    }

    IEnumerator showPopup(GameObject popup)
    {
        popup.SetActive(true);
        yield return new WaitForSeconds(2);
        popup.SetActive(false);
    }

}