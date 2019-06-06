using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Blazaco.Editor
{
    public class BlazacoJSInterop
    {
        private readonly IJSRuntime runtime;
        private readonly EditorModel model;

        public BlazacoJSInterop(IJSRuntime runtime, EditorModel model)
        {
            this.runtime = runtime;
            this.model = model;
        }

        public delegate Task<T> Executor<T>(string func, params object[] args);

        public Task<T> InvokeEditorMethod<T>(string func, params object[] args)
        {
            return runtime.InvokeAsync<T>("Blazaco.Editor.CallEditorMethod",
                new object[] { model.Id, func, args });
        }

        public Task<T> InvokeEditorModelMethod<T>(string func, params object[] args)
        {
            return runtime.InvokeAsync<T>("Blazaco.Editor.CallEditorModelMethod",
                new object[] { model.Id, func, args });
        }

        public Task<bool> InitializeEditor()
             => runtime.InvokeAsync<bool>("Blazaco.Editor.InitializeEditor", new[] { model });

        ///
        // public Task<T> CallEditorMethod<T>(string func, params object[] args) => InvokeEditorMethod<T>(func, args);

        // public Task<T> CallEditorMethod<T>(string func) => InvokeEditorMethod<T>(func, null);

        // public Task CallEditorMethod(string func) => InvokeEditorMethod<bool>(func, null);

        // public Task CallEditorMethod(string func, params object[] args) => InvokeEditorMethod<bool>(func, args);

        // ///
        // public Task CallEditorModelMethod(string func, params object[] args) => InvokeEditorModelMethod<bool>(func, args);

        // public Task<T> CallEditorModelMethod<T>(string func, params object[] args) => InvokeEditorModelMethod<T>(func, args);

        // public Task<T> CallEditorModelMethod<T>(string func) => InvokeEditorModelMethod<T>(func, null);

        // public Task CallEditorModelMethod(string func) => InvokeEditorModelMethod<bool>(func, null);

    }


}
