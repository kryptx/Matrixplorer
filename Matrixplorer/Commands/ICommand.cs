using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrixplorer.Commands {
    interface ICommand {
        bool Execute();
        void Undo();
    }
}
