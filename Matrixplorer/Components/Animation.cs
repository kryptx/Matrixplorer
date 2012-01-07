using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Microsoft.Xna.Framework;

namespace Matrixplorer.Components {

    // where T: struct allows more than we really want,
    // but it is the narrowest constraint that will allow 
    // all the types that are appropriate in this context
    class Animation<T> where T: struct {

        private T initial;
        private T final;
        private uint duration;
        private Stopwatch timer;

        public Animation(T initial, T final, uint duration = 1000) {

            this.initial = initial;
            this.final = final;
            this.duration = duration;

            timer = new Stopwatch();
            timer.Start();

        }

        public bool Ended {
            get {
                return timer.ElapsedMilliseconds >= duration;
            }
        }

        public T CurrentValue {
            get {
                return (timer.ElapsedMilliseconds >= duration) ?
                    final :
                    Lerp(initial, final, ((float)timer.ElapsedMilliseconds / (float)duration));
            }
        }

        // i and f are of type T, and if T makes sense for animations then they
        // can be added/subtracted, but the compiler complains if we try that
        private T Lerp(dynamic i, dynamic f, float amount) {
            return i + ((f - i) * amount);
        }

    }

}
