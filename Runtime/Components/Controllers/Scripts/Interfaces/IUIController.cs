using System.Collections;
using System.Collections.Generic;
using pippinmole.UI;
using UnityEngine;

public interface IUIController {
     void ToggleVisibility();
     void ResetVisibility();
     void SetMenuState(bool state);
     void SetMenuState(UIControllerComponent.EState state);
}