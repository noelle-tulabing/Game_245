using System;
using States;
using UnityEngine;

public class PlayerInteraction : Player
{
    public void PlayerClicked(GameObject hit)
    {
        IClickable validClick = hit.transform.gameObject.GetComponent<IClickable>();
        if (hit.transform.gameObject.gameObject.GetComponent<CaseFile>() != null)
        {
            CaseFile caseFile = hit.transform.gameObject.GetComponent<CaseFile>();
            CaseFileFound(caseFile);
            Destroy(caseFile.gameObject);
        }
        else if (hit.transform.gameObject.GetComponent<Focus>() != null)
        {
            Focus focus = hit.transform.gameObject.GetComponent<Focus>();
            focus.OnClick();
        }
        else if (Inventory.getItem(Inventory.checkSelected()) !=null)
        {
                    
            Debug.Log("Player is using " + Inventory.getItem(Inventory.checkSelected()).name + " on " + hit.GetComponent<Collider>().gameObject.name);
            Collectable useItem = Inventory.getItem(Inventory.checkSelected());
            Collider onObject = hit.GetComponent<Collider>();
            if (useItem != null && useItem.use(onObject))
            {
                useItem.use(onObject);
            }
            else
            {
                Debug.Log("cannot use " + useItem.name + " on " + onObject.name);
                hit.GetComponent<Collider>().gameObject.GetComponent<IClickable>().OnClick();
            }
        }
        else
        {
            validClick.OnClick();
        }
    }
    
    public void CaseFileFound(CaseFile caseFile)
    {
        Debug.Log("current case files found: " + GetFilesFound());
        newFileFound();
        Destroy(caseFile.gameObject);
        Debug.Log("updated case files found: " + GetFilesFound());
        if (GetFilesFound() == 1)
        {
            Debug.Log("switching state to game playing state");
            manager.NewGameState(manager.stateGamePlaying);
        }
    }

}
