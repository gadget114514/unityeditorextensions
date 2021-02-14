using System;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

/// <summary>
/// アニメーターのステート名を定数で管理するクラスを作成するスクリプト
/// </summary>
/// 
/// comes from  https://gist.github.com/baba-s/4d3c707e6059963e0653
/// baba - s / AnimatorStateNameCreator.cs
/// 
namespace bluen.Editor
{
    public static class AnimatorStateNameCreator
    {
        // 無効な文字を管理する配列
        private static readonly string[] INVALID_CHARS =
        {
        " ", "!", "\"", "#", "$",
        "%", "&", "\'", "(", ")",
        "-", "=", "^",  "~", "\\",
        "|", "[", "{",  "@", "`",
        "]", "}", ":",  "*", ";",
        "+", "/", "?",  ".", ">",
        ",", "<"
    };

        private const string ITEM_NAME = "Tools/bluen/Create/Animator State Name";  
        private const string PATH = "Assets/Scripts/AnimatorStateName.cs";       

        private static readonly string FILENAME = Path.GetFileName(PATH);                 // ファイル名( 拡張子あり )
        private static readonly string FILENAME_WITHOUT_EXTENSION = Path.GetFileNameWithoutExtension(PATH); // ファイル名( 拡張子なし )

        /// <summary>
        /// アニメーターのステート名を定数で管理するクラスを作成します
        /// </summary>
        [MenuItem(ITEM_NAME)]
        public static void Create()
        {
            if (!CanCreate())
            {
                return;
            }

            var builder = new StringBuilder();

            builder.AppendLine("/// <summary>");
            builder.AppendLine("/// Animator name managed by constant value");
            builder.AppendLine("/// </summary>");
            builder.AppendLine("public static class AnimatorStateName");
            builder.AppendLine("{");

            var controllers = AssetDatabase
                .GetAllAssetPaths()
                .Select(c => AssetDatabase.LoadAssetAtPath(c, typeof(AnimatorController)))
                .OfType<AnimatorController>();

            foreach (var controller in controllers)
            {
                builder.Append("\t").AppendFormat("public static class {0}", controller.name);
                builder.Append("\t").AppendLine();
                builder.Append("\t").AppendLine("{");

                var clips = controller.layers
                    .SelectMany(c => c.stateMachine.states)
                    .Select(c => c.state.motion)
                    .OfType<AnimationClip>();

                foreach (var clip in clips)
                {
                    var val = RemoveInvalidChars(clip.name);
                    builder.Append("\t\t").AppendFormat(@"public const string {0} = ""{1}"";", val, clip.name);
                    builder.Append("\t\t").AppendLine();
                }

                builder.Append("\t").AppendLine("}");
            }

            builder.AppendLine("}");

            var directoryName = Path.GetDirectoryName(PATH);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }

            File.WriteAllText(PATH, builder.ToString(), Encoding.UTF8);
            AssetDatabase.ImportAsset(PATH);
            var message = string.Format("{0} is generated as constant definition file", FILENAME);
            EditorUtility.DisplayDialog(string.Empty, message, "OK");
            var obj = AssetDatabase.LoadAssetAtPath(PATH, typeof(TextAsset));
            EditorGUIUtility.PingObject(obj);
        }

        /// <summary>
        /// アニメーターのステート名を定数で管理するクラスを作成できるかどうかを取得します
        /// </summary>
        [MenuItem(ITEM_NAME, true)]
        public static bool CanCreate()
        {
            return
                !EditorApplication.isPlaying &&
                !EditorApplication.isCompiling &&
                !Application.isPlaying;
        }

        /// <summary>
        /// 無効な文字を削除します
        /// </summary>
        public static string RemoveInvalidChars(string str)
        {
            Array.ForEach(INVALID_CHARS, c => str = str.Replace(c, string.Empty));
            return str;
        }
    }
}