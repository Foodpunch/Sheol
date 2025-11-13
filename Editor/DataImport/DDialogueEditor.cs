using UnityEditor;
using ProjectRuntime.Data;

#if UNITY_EDITOR
namespace ProjectEditor.Data
{
    [CustomEditor(typeof(DDialogue))]
    public class DDialogueEditor : MultiTextBoxEditor<DDialogue> { }
}
#endif
