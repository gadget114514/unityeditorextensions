using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.PackageManager;

// comes from internet somewhere
// notice to me; thanks to author

namespace bluen.Editor
{
    public static class UPMDependenciesList { 



//    public static class UPMDependenciesTools

        [MenuItem("Tools/bluen/Package Management/Print all dependencies")]
        public static async void PrintAllDependencies()
        {
            var request = Client.List();

            while (!request.IsCompleted)
            {
                await Task.Yield();
            }

            var collection = request.Result;
            var stringBuilder = new StringBuilder();

            foreach (var item in collection)
            {
                stringBuilder.AppendLine($"{item.name}@{item.version}");

                foreach (var dependency in item.dependencies)
                {
                    stringBuilder.AppendLine($"---- {dependency.name}@{dependency.version}");
                }
            }

            Debug.Log(stringBuilder);
        }
    }
}