﻿using NAudio.Wave.SampleProviders;
using Synthesizer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Synthesizer.ViewModel
{
    public class KeyboardViewModel : ViewModelBase
    {        
        
        public static List<KeyboardManager> keyboardNotes = new List<KeyboardManager>
        {
            new KeyboardManager{ keyNote = Key.Q, TypeNote = "raw", ButtonName = "Q" },             
            new KeyboardManager{ keyNote = Key.D1, TypeNote = "sharp", ButtonName = "D1" }, 
            new KeyboardManager{ keyNote = Key.D2, TypeNote = "raw", ButtonName = "D2" },
            new KeyboardManager{ keyNote = Key.D3, TypeNote = "sharp", ButtonName = "D3" },
            new KeyboardManager{ keyNote = Key.D4, TypeNote = "raw", ButtonName = "D4" },
            new KeyboardManager{ keyNote = Key.D5, TypeNote = "raw", ButtonName = "D5" },
            new KeyboardManager{ keyNote = Key.D6, TypeNote = "sharp", ButtonName = "D6" },
            new KeyboardManager{ keyNote = Key.D7, TypeNote = "raw", ButtonName = "D7" },
            new KeyboardManager{ keyNote = Key.D8, TypeNote = "sharp", ButtonName = "D8" },
            new KeyboardManager{ keyNote = Key.D9, TypeNote = "raw", ButtonName = "D9" },
            new KeyboardManager{ keyNote = Key.D0, TypeNote = "sharp", ButtonName = "D0" },
            new KeyboardManager{ keyNote = Key.P, TypeNote = "raw", ButtonName = "P" },
            new KeyboardManager{ keyNote = Key.A, TypeNote = "raw", ButtonName = "A" },
            new KeyboardManager{ keyNote = Key.S, TypeNote = "sharp", ButtonName = "S" },
            new KeyboardManager{ keyNote = Key.D, TypeNote = "raw", ButtonName = "D" },
            new KeyboardManager{ keyNote = Key.F, TypeNote = "sharp", ButtonName = "F" },
            new KeyboardManager{ keyNote = Key.G, TypeNote = "raw", ButtonName = "G" },
            new KeyboardManager{ keyNote = Key.H, TypeNote = "white", ButtonName = "H" },
            new KeyboardManager{ keyNote = Key.J, TypeNote = "sharp", ButtonName = "J" },
            new KeyboardManager{ keyNote = Key.K, TypeNote = "raw", ButtonName = "K" },
            new KeyboardManager{ keyNote = Key.L, TypeNote = "sharp", ButtonName = "L" },
            new KeyboardManager{ keyNote = Key.Z, TypeNote = "raw", ButtonName = "Z" },
            new KeyboardManager{ keyNote = Key.X, TypeNote = "sharp", ButtonName = "X" },
            new KeyboardManager{ keyNote = Key.C, TypeNote = "raw", ButtonName = "C" },           
        };

       
    }
}

