using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;

public class imageController : MonoBehaviour
{
    private List<RaycastResult> list = new List<RaycastResult>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            GameObject go = null;
            if (EventSystem.current.IsPointerOverGameObject())
            {
                go = clickUI();
            }
            else {

            }

            if (go == null)
            {
                //Debug.Log("Click Nothing");
            }
            else {
                if (go.tag == "static")
                    return;
                Debug.Log("Click UI");
#if UNITY_EDITOR
                EditorGUIUtility.PingObject(go);
                Selection.activeObject = go;
#endif

                // update image
                Image image = go.GetComponent<Image>();
                image.color = Color.black;
            }
        }
    }

    private GameObject clickUI() {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        EventSystem.current.RaycastAll(eventData, list);
        var raycast = FindFirstRaycast(list);
        var go = ExecuteEvents.GetEventHandler<IEventSystemHandler>(raycast.gameObject);
        if (go == null)
        {
            go = raycast.gameObject;
        }
        return go;
    }

    private RaycastResult FindFirstRaycast(List<RaycastResult> candidates)
    {
        for (var i = 0; i < candidates.Count; ++i)
        {
            if (candidates[i].gameObject == null)
                continue;

            return candidates[i];
        }
        return new RaycastResult();
    }
}
