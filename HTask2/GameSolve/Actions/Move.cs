﻿using HTask2.GameSolve.Interfaces;
using HTask2.GameSolve.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTask2.GameSolve.Actions
{
    public class Move
    {
        Movable _movable;
        public Move(Movable movable)
        {
            _movable = movable;
        }
        

        public void Execute()
        {
            if (this._movable == null)
                throw new Exception("Объект, реализующий интерфейс Movable, не определен.");

            _movable.Set(this._movable.CurrentVector.Add(this._movable.CurrentVector));
        }
    }
}
