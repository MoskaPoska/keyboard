using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {      
        public MainWindow()
        {        
            InitializeComponent();
            KeyDown += MainWindowKeyDown;
            KeyUp += MainWindowKeyUp;          
        }
        private void MainWindowKeyUp(object sender, KeyEventArgs e)
        {
            Border keyColorUp = FindKeyControl(e.Key);
            if (keyColorUp != null)
            {
                keyColorUp.Background = Brushes.White;
            }
        }
        private void MainWindowKeyDown(object sender, KeyEventArgs e)
        {
            string pressKey = KeyToChar(e.Key, Keyboard.IsKeyDown(Key.LeftShift));
            if (!string.IsNullOrEmpty(pressKey))
            {
                print.Text += pressKey;
                Border keyColor = FindKeyControl(e.Key);               
            }
        }
        private Border FindKeyControl(Key key)
        {
            Dictionary<Key, Border>  redKeyBorders = new Dictionary<Key, Border>
            {
                 { Key.A,AKey },
                 { Key.Z, ZKey },
                 { Key.Q, QKey },
                 { Key.Oem3, AposKey },
                 { Key.D1, OneKey },
                 { Key.D2, TwoKey},
                 { Key.D9, NineKey},
                 { Key.I, IKey},
                 { Key.K, KKey},
                 { Key.OemComma, ComaKey}
             };
            Dictionary<Key, Border> yellowKeyBorders = new Dictionary<Key, Border>
            {
                { Key.X, XKey},
                { Key.S, SKey },
                { Key.W, WKey},
                { Key.D3, TriKey},
                { Key.OemPeriod, DotKey},
                { Key.L, LKey},
                { Key.O,OKey},
                { Key.D0, Zerokey}
            };
            Dictionary<Key, Border> greenKeyBorders = new Dictionary<Key, Border>
            {
                { Key.C, CKey },
                { Key.D, DKey},
                { Key.E, EKey },
                { Key.D4, FourKey },
                { Key.OemComma, ComaKey},
                { Key.OemSemicolon, DotComaKey},
                { Key.OemQuotes, OneQuotesKey},
                { Key.P, PKey},
                { Key.OemOpenBrackets, LeftBracketsKey},
                { Key.OemCloseBrackets, RightBracketsKey},
                { Key.OemPipe, RightSleshKey},
                { Key.OemQuestion ,SleshKey},
                { Key.OemMinus, MinusKey},
                { Key.OemPlus, EqualKey}
            };
            Dictionary<Key, Border> purpleKeyBorders = new Dictionary<Key, Border>
            {
                { Key.M, MKey},
                { Key.J, JKey},
                { Key.U, UKey},
                { Key.D8, EightKey},
                { Key.D7, SevenKey},
                { Key.Y, YKey},
                { Key.H, HKey},
                { Key.N, NKey}
            };
            Dictionary<Key, Border> blueKeyBorders = new Dictionary<Key, Border>
            {
                { Key.B, BKey},
                { Key.G, GKey},
                { Key.T, TKey},
                { Key.D6, SixKey},
                { Key.D5, FiveKey},
                { Key.R, RKey},
                { Key.F, FKey},
                { Key.V, VKey}
            };
            if(blueKeyBorders.TryGetValue(key, out var blueKeyBorder))
            {
                blueKeyBorder.Background = Brushes.SkyBlue;
                return blueKeyBorder;
            }
            if (purpleKeyBorders.TryGetValue(key, out var purpleKeyBorder))
            {
                purpleKeyBorder.Background = Brushes.MediumPurple;
                return purpleKeyBorder;
            }
            if (redKeyBorders.TryGetValue(key, out var redKeyBorder))
            {
                redKeyBorder.Background = Brushes.Red;
                return redKeyBorder;
            }
            if (yellowKeyBorders.TryGetValue(key, out var yellowKeyBorder))
            {
                yellowKeyBorder.Background = Brushes.Yellow;
                return yellowKeyBorder;
            } 
            if(greenKeyBorders.TryGetValue(key, out var greenKeyBorder))
            {
                greenKeyBorder.Background= Brushes.Lime;
                return greenKeyBorder;
            }  
            return null;
        }
        private string KeyToChar(Key key, bool shiftPressed)
        {
            bool capsLock = Console.CapsLock;
            if (key >= Key.A && key <= Key.Z)
            {
                return (capsLock ^ shiftPressed) ? ((char)('A' + (key - Key.A))).ToString() : ((char)('a' + (key - Key.A))).ToString();
            }
            if (key >= Key.D0 && key <= Key.D9) 
            {
                return shiftPressed ? ((char)('0' + key - Key.D0)).ToString() : ((char)('0' + key - Key.D0)).ToString();
            }
            else
            {
                switch (key)
                {
                    case Key.OemTilde:
                        return shiftPressed ? "~" : "`";
                    case Key.OemMinus:
                        return shiftPressed ? "_" : "-";
                    case Key.OemPlus:
                        return shiftPressed ? "+" : "=";
                    case Key.OemComma:
                        return shiftPressed ? "<" : ",";
                    case Key.OemPeriod:
                        return shiftPressed ? ">" : ".";
                    case Key.OemQuestion:
                        return shiftPressed ? "?" : "/";
                    case Key.OemOpenBrackets:
                        return shiftPressed ? "{" : "[";
                    case Key.OemCloseBrackets:
                        return shiftPressed ? "}" : "]";
                    case Key.OemSemicolon:
                        return shiftPressed ? ":" : ";";
                    case Key.OemQuotes:
                        return shiftPressed ? "\"" : "'";
                    case Key.OemPipe:
                        return shiftPressed ? "|" : "\\";
                    case Key.Space:
                        return shiftPressed ? string.Empty : "\u0020";//\u0020 - исмвол пробела
                    default:
                        return string.Empty;
                }
            }
        }      
    }
}

