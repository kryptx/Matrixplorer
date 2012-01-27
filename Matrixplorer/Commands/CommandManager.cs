using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrixplorer.Commands {

    public static class CommandManager {

        private static Stack<ICommand> undoStack;
        private static Stack<ICommand> redoStack;

        public static void Init() {
            undoStack = new Stack<ICommand>(100);
            redoStack = new Stack<ICommand>(100);
        }

        public static void DoCommand(ICommand command) { 
            if (command.Execute()) {
                undoStack.Push(command);
                redoStack.Clear();
            }
        }

        public static void Undo() {
            if (undoStack.Count > 0) {
                ICommand command = undoStack.Peek();
                redoStack.Push(undoStack.Pop().Undo());
            }
        }

        public static void Redo() {
            if (redoStack.Count > 0) {
                ICommand command = redoStack.Peek();
                if (command.Execute())
                    undoStack.Push(redoStack.Pop());
            }
        }

    }

}
