using System.IO;
using System.Text;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;
using static System.String;

#if UNITY_EDITOR
#endif

#if ODIN_INSPECTOR
#endif

namespace N8.Utils.SOA.Editor.Editor
{
    internal sealed class ScriptableObjectVariableCreationWindow : OdinEditorWindow
    {
        private const string 
            NAME = "#NAME",
            NAMESPACE = "#NAMESPACE",
            TYPE = "#TYPE",
            MENU_NAME = "#MENU_NAME",
            FILE_NAME = "#FILE_NAME",
            IS_READONLY = "Readonly",
            IS_NOT_READONLY = "",
            IS_WRITING_VARIABLE = nameof(_isWriting);
        
        private readonly string[] _templateFile = 
        {
            "using UnityEngine;",
            "using Sirenix.OdinInspector;",
            "",
            $"namespace {NAMESPACE}",
            "{",
            $"\t[CreateAssetMenu(fileName = \"New#NAME\", menuName = \"N8/Utils/SOA/Variables/{MENU_NAME}\"), InlineEditor]",
            $"\tpublic sealed class {IS_READONLY}{NAME} : {IS_READONLY}Variable<{TYPE}>",
            "\t{",
            "",
            "\t}",
            "}"
        };

        [SerializeField] 
        [DisableIf(IS_WRITING_VARIABLE)]
        private string
            _type = "UnityEngine.Object",
            _namespace = "n8dev.SOA",
            _className = "ObjectVariable",
            _menuName = "Object",
            _newFileName = "NewObject",
            _pathToFolder;

        private bool 
            _isWriting;
        
        private bool IsAnythingBlank =>
            IsNullOrWhiteSpace(_type) ||
            IsNullOrWhiteSpace(_namespace) ||
            IsNullOrWhiteSpace(_className) ||
            IsNullOrWhiteSpace(_menuName) ||
            IsNullOrWhiteSpace(_newFileName) ||
            IsNullOrWhiteSpace(_pathToFolder);

        [MenuItem("Tools/SOA/Create New ScriptableObject Variable Type")]
        private static void ShowWindow() => GetWindow<ScriptableObjectVariableCreationWindow>().Show();

        [Button(ButtonSizes.Small)]
        private void Create()
        {
            if (_isWriting)
            {
                Debug.LogWarning($"{_className}.cs is still being generated. Wait for it to be finished.");
                return;
            }
            if (IsAnythingBlank)
            {
                Debug.LogWarning("Make sure everything is filled out homie.");
                return;
            }
            _isWriting = true;
            CreateNewVariable(false);
            CreateNewVariable(true);
            ClearDetails();
            _isWriting = false;
        }



        private void CreateNewVariable(bool isReadonly)
        {
            var prefix = isReadonly ? IS_READONLY : IS_NOT_READONLY;
            var fileName = $"{prefix}{_className}.cs";
            var path = $"{_pathToFolder}/{fileName}";
            
            if (File.Exists(path))
            {
                Debug.LogWarning($"There is already a file with the name {fileName}, name it something different.");
                return;
            }
            
            Debug.Log($"Generating {fileName} script...");
            try
            {
                using var streamWriter = new StreamWriter(path);
                streamWriter.Write(GenerateScript(isReadonly));
            }
            catch (IOException)
            {
                _isWriting = false;
                throw;
            }
        }

        private string GenerateScript(bool isReadonly)
        {
            var script = new StringBuilder();
            foreach (var line in _templateFile)
                script.AppendLine(line);
            
            if (!isReadonly) 
                script.Replace(IS_READONLY, Empty);
            
            script.Replace(NAMESPACE, _namespace);
            script.Replace(NAME, _className);
            script.Replace(TYPE, _type);
            script.Replace(MENU_NAME, _menuName);
            script.Replace(FILE_NAME, _newFileName);

            return script.ToString();
        }

        private void ClearDetails()
        {
            _type = Empty;
            _className = Empty;
            _menuName = Empty;
            _newFileName = Empty;
        }
    }
}