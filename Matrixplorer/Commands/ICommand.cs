using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrixplorer.Commands {
    interface ICommand {
        void Execute();
        void Undo();
    }
}
