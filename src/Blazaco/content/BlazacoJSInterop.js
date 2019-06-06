window.Blazaco = window.Blazaco || {};
window.Blazaco.Editors = [];


function GetEditorByID(id) {
    let myEditor = window.Blazaco.Editors.find(e => e.id === id);
    if (!myEditor) {
        throw `Could not find a editor with id: '${window.Blazaco.Editors.length}' '${id}'`;
    }
    return myEditor;
}

window.Blazaco.Editor = {
    InitializeEditor: function (model) {
        let thisEditor = monaco.editor.create(document.getElementById(model.id), model.options);
        if (window.Blazaco.Editors.find(e => e.id === model.id)) {
            return false;
        }
        else {
            window.Blazaco.Editors.push({ id: model.id, editor: thisEditor });
        }
        return true;
    },

    CallEditorMethod: function (id, func, args) {
        let myEditor = GetEditorByID(id);
        let fun = myEditor[func];
        if (!fun) {
            let error = `Invalid function call '${func}' on editor`;
            alert(error)
            throw error;
        }

        return fun.apply(myEditor, args)
    },

    CallEditorModelMethod: function (id, func, args) {
        let myEditor = GetEditorByID(id);
        let model = myEditor.editor.getModel()
        let fun = model[func];
        if (!fun) {
            let error = `Invalid function call '${func}' on editor-model`;
            alert(error)
            throw error;
        }

        return fun.apply(model, args)
    },

    EvalUnsafe: function (id, code) {
        let myEditor = GetEditorByID(id);
        return eval(code);
    }

}


