using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuNavigationManager : MonoBehaviour
{
    [SerializeField]
    MenuController initialMenu = null;

    MenuController currentMenu = null;
    Stack<MenuController> previous = new Stack<MenuController>();
    Stack<MenuController> next = new Stack<MenuController>();

    private void Start() {
        if (initialMenu != null) {
            currentMenu = initialMenu;
            currentMenu.Enter();
        }
    }

    public void GoTo(MenuController menu) {
        if (currentMenu != null) {
            currentMenu.Exit();
            previous.Push(currentMenu);
            next.Clear();
        }
        currentMenu = menu;
        currentMenu.Enter();
    }

    public void GoBack() {
        if (currentMenu != null) {
             currentMenu.Exit();
            next.Push(currentMenu);
        }
        currentMenu = previous.Pop();
        currentMenu.Enter();
    }
    public void GoForward() {
        if (currentMenu != null) {
            currentMenu.Exit();
            previous.Push(currentMenu);
        }
        currentMenu = next.Pop();
        currentMenu.Enter();
    }
}