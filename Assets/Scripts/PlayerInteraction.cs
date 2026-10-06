using UnityEngine;

public class PlayerInteraction : MonoBehaviour, IClickable
{
    //public Inventory inventory;
    public Collectable collectable;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void use(Collider item)
    {
        
    }

    public void OnClick()
    {
        if (Inventory.checkSelected() == -1)
        {
            return;
        }
        int index = Inventory.checkSelected();
        Debug.Log("player has selected index: " + index);
        Debug.Log("checking if item: " + Inventory.getItem(index).name + " against " + collectable.name);
        if (Inventory.getItem(index) == collectable)
        {
            Debug.Log("you win!");
        }
    }
}
