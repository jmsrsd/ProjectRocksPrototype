using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterWeaponController : MonoBehaviour
{
    public void SetWeapon(int index)
    {
       try {
            for (var i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        transform.GetChild(index).gameObject.SetActive(true);
       } catch (System.Exception e) {
           Debug.Log(e.Message);
       }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeapon(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetWeapon(2);
        }
    }
}
