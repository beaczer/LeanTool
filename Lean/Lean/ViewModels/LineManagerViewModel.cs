﻿using Caliburn.Micro;
using Lean.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lean
{
    public class LineManagerViewModel:Screen
    {
        public List<Line> ListOfLine { get; set; } = new List<Line>();
        public void AddLine(string Text)
        {
            Line line = new Line(Text);
        }

    }
}