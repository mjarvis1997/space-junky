using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{
    /******************** GAME OBJECT MANIPULATION ********************/

   // given a game object, locates the first parent that doesn't have a generic name
    public static string findNameOfNonGenericParent(GameObject go) {
        string name = go.name;

        // if go is generic
        if(isObjectNameGeneric(name)) 
        {
            // recursively call this function on the parent object
            name = findNameOfNonGenericParent(go.transform.parent.gameObject);
        }

        return name;
    }

    public static GameObject findNonGenericParent(GameObject go) 
    {
        GameObject tempGo = go;

         // if go is generic
        if(isObjectNameGeneric(go.name)) 
        {
            // recursively call this function on the parent object
            tempGo = findNonGenericParent(go.transform.parent.gameObject);
        }

        return tempGo;
    }

    private static string[] genericObjectNames = new string[] {"Collider", "Sprite"};

    // checks if a string contains the generic phrases we use
    public static bool isObjectNameGeneric(string name)
    {
        // if name contains a generic phrase
        foreach (string genericName in genericObjectNames)
        {
            if(name.Contains(genericName))
            {
                return true;
            }
        }

        // if name does not contain generic phrase
        return false;
    }

    /******************** LOGGING ********************/

    public static void logCollision(string name1, string name2) 
    {
        Debug.Log("COLLISION: [" + name1 + "] collided with [" + name2 + "]");
    }

    public static void logEvent(string eventName, string eventLocation) 
    {
        Debug.Log("EVENT: [" + eventName + "] heard from [" + eventLocation + "]");
    }

    public static void logDamage(string damageTaker, string damageDoer, float damage) 
    {
        Debug.Log("DAMAGE: [" + damageTaker + "] took [" + damage + "] damage from [" + damageDoer + "]");
    }
    
}
