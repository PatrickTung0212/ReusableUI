using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Patrick.UI
{
public class UIMenu : MonoBehaviour
{

        #region Variables



        #endregion

        #region HelpMethod
        [MenuItem("PatrickUI/UI Tools/Create UI Group")]
        public static void CreateUIGroup()
        {
            //Debug.Log("Creating UI Group");
            GameObject uiGroup = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/Menu.prefab");
            if (uiGroup)
            {
                GameObject createdGroup = (GameObject)Instantiate(uiGroup);
                createdGroup.name = "UI_Group";
            }
            else
            {
                EditorUtility.DisplayDialog("UI Tools Warning", "Cannot find UI Group Prefab","OK");
            }
        }
        #endregion
    }

}
