using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrixplorer.Commands {
    public interface ICommand {
        bool Execute();
        ICommand Undo();
    }
}
