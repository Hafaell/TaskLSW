using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Shop
{
    public class MouseOverUI : MonoBehaviour
    {
        public static GameObject GetMouseOverUIElement()
        {
            return GameObjectUIElement(GetEventSystemRaycastResults());
        }

        static GameObject GameObjectUIElement(List<RaycastResult> eventSystemRaycastResults)
        {
            for (int index = 0; index < eventSystemRaycastResults.Count; index++)
            {
                RaycastResult curRaysastResult = eventSystemRaycastResults[index];
                if (curRaysastResult.gameObject.layer == LayerMask.NameToLayer("ItemUI"))
                    return curRaysastResult.gameObject;
            }

            return null;
        }

        static List<RaycastResult> GetEventSystemRaycastResults()
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;
            List<RaycastResult> raysastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raysastResults);
            return raysastResults;
        }
    }
}
