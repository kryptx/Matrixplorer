using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Microsoft.Xna.Framework;

namespace Matrixplorer.Components {

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

        // i and f are of type T, and we know they can be added/subtracted,
        // but the compiler complains if we try that
        private T Lerp(dynamic i, dynamic f, float amount) {
            return i + ((f - i) * amount);
        }

    }

}
