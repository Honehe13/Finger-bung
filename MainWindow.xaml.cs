using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fingerübung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
     
    public partial class MainWindow : Window
    {
        Spieler player1, player2; 
        Line line = new Line();
        public MainWindow()
        {

            player1 = new Spieler(true, "X");
            player2 = new Spieler(false, "O");

            InitializeComponent();

            //Bindung der Property Wins an die Labels
            p1win.DataContext = player1;
            p2win.DataContext = player2;
        }

        
        //Methode für Spieler 1
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender; 
            
            if (player1.AmZug && btn.Content == null) //Wenn Spieler 1 am Zug ist und der geklickte Button noch leer ist
            {
                btn.Content = player1.Zeichen; //Button wird mit X markiert
                nextTurn();
            }
        }


        //Hat jemand gewonnen
        private void checkForVictory()
        {
            //Wenn die oberste Reihe gleiche Werte hat aber nicht leer ist
            if (Button11.Content == Button12.Content && Button12.Content == Button13.Content && Button12.Content != null)
            {
                //Gewonnen
                gewonnen(Button11.Content.ToString());
                drawWinningLine(1,1);
            }
            //Wenn die mittlere Reihe gleiche Werte hat aber nicht leer ist
            if (Button21.Content == Button22.Content && Button22.Content == Button23.Content && Button22.Content != null)
            {
                //Gewonnen
                gewonnen(Button21.Content.ToString());
                drawWinningLine(2, 2);
            }
            //Wenn die untere Reihe gleiche Werte hat aber nicht leer ist
            if (Button31.Content == Button32.Content && Button32.Content == Button33.Content && Button32.Content != null)
            {
                //Gewonnen
                gewonnen(Button31.Content.ToString());
                drawWinningLine(3, 3);
            }
            //Wenn die 1. Reihe gleiche Werte hat aber nicht leer ist
            if (Button11.Content == Button21.Content && Button21.Content == Button31.Content && Button21.Content != null)
            {
                //Gewonnen
                gewonnen(Button11.Content.ToString());
                drawWinningLine(1);
            }
            //Wenn die 2. Reihe gleiche Werte hat aber nicht leer ist
            if (Button12.Content == Button22.Content && Button22.Content == Button32.Content && Button22.Content != null)
            {
                //Gewonnen
                gewonnen(Button12.Content.ToString());
                drawWinningLine(2);
            }
            //Wenn die 3. Reihe gleiche Werte hat aber nicht leer ist
            if (Button13.Content == Button23.Content && Button23.Content == Button33.Content && Button23.Content != null)
            {
                //Gewonnen
                gewonnen(Button13.Content.ToString());
                drawWinningLine( 3);
            }
            //Wenn \ gleiche Werte hat aber nicht leer ist
            if (Button11.Content == Button22.Content && Button22.Content == Button33.Content && Button22.Content != null)
            {
                //Gewonnen
                gewonnen(Button11.Content.ToString());

                drawWinningLine(1, 3);
            }

            //Wenn / gleiche Werte hat aber nicht leer ist
            if (Button31.Content == Button22.Content && Button22.Content == Button13.Content && Button22.Content != null)
            {
                //Gewonnen
                gewonnen(Button31.Content.ToString());

                drawWinningLine(3, 1);
            }

        }

        //Nächster Spieler ist dran
        private void nextTurn()
        {
            player1.AmZug = !player1.AmZug; //Zugberechtigung wird gewechselt
            player2.AmZug = !player2.AmZug;
            checkForVictory(); // Hat jemand gewonnen?
        }

        //Gewonnen
        private void gewonnen(string XoderO)
        {
            //Gewonnen
            if (XoderO == player1.Zeichen)
            {
                MessageBox.Show("Spieler 1 hat gewonnen");
                player1.Wins += 1;
            }
            else if (XoderO == player2.Zeichen)
            {
                MessageBox.Show("Spieler 2 hat gewonnen");
                player2.Wins += 1;
            }
            else //Abfangen von Fehler durch falschen Übergabewert.
            {
                MessageBox.Show("Falscher Übergabewert in gewonnen(). " + XoderO);
            }

            //Niemand kann mehr ziehen. Spiel vorbei
            player1.AmZug = false;
            player2.AmZug = false;
        }


        //Spieler 2 (NumPad) ist dran
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (player2.AmZug) //Nur wenn Spieler 2 auch am Zug ist
            {
                if (e.Key == Key.NumPad1 && Button31.Content==null) // Feld unten Links wurde "geklickt" und ist auch noch leer
                {
                    Button31.Content = player2.Zeichen; //Button mit O beschreiben
                    nextTurn();
                }
                else if (e.Key == Key.NumPad2 && Button32.Content == null)
                {
                    Button32.Content = player2.Zeichen;
                    nextTurn();
                }

                else if (e.Key == Key.NumPad3 && Button33.Content == null)
                {
                    Button33.Content = player2.Zeichen;
                    nextTurn();
                }
                else if (e.Key == Key.NumPad4 && Button21.Content == null)
                {
                    Button21.Content = player2.Zeichen;
                    nextTurn();
                }
                else if (e.Key == Key.NumPad5 && Button22.Content == null)
                {
                    Button22.Content = player2.Zeichen;
                    nextTurn();
                }
                else if (e.Key == Key.NumPad6 && Button23.Content == null)
                {
                    Button23.Content = player2.Zeichen;
                    nextTurn();
                }
                else if (e.Key == Key.NumPad7 && Button11.Content == null)
                {
                    Button11.Content = player2.Zeichen;
                    nextTurn();
                }
                else if (e.Key == Key.NumPad8 && Button12.Content == null)
                {
                    Button12.Content = player2.Zeichen;
                    nextTurn();
                }
                else if (e.Key == Key.NumPad9 && Button13.Content == null)
                {
                    Button13.Content = player2.Zeichen;
                    nextTurn();
                }
                
                
            }
        }


        //neues Spiel
        private void Neu_Click(object sender, RoutedEventArgs e)
        {
            //Buttons wieder zurücksetzten
            Button11.Content = null;
            Button12.Content = null;
            Button13.Content = null;
            Button21.Content = null;
            Button22.Content = null;
            Button23.Content = null;
            Button31.Content = null;
            Button32.Content = null;
            Button33.Content = null;


            //Spieler 1 fängt wieder an
            player1.AmZug = true;

            //Linie löschen
            Spielfeld.Children.Remove(line);
        }

        //Linie zeichnen, die den Gewinn darstellt. Übergeben wird die Zeile in der die Linie startet und die Zeile, wo sie endet
        private void drawWinningLine(int rowStart, int rowEnd)
        {
            if ((rowStart <= 3 && rowStart > 0) && (rowEnd <= 3 && rowEnd > 0)) //Haben die Übergabeparameter gültige Werte?
            {
                // Das Spielfeld wird zum Zeichnen der Linie gesechstelt, damit der Start bzw das Ende der Linie in der Mitte des Buttons liegt.
                // Deshalb entspricht Zeile 2 der Hälfte des Feldes also 3/6 und Zeile 3 5/6
                int y1 = 1;
                int y2 = 1;
                if (rowStart == 2)
                    y1 = 3;
                else if (rowStart == 3)
                    y1 = 5;
                if (rowEnd == 2)
                    y2 = 3;
                else if (rowEnd == 3)
                    y2 = 5;
                
                line = new Line();
                line.StrokeThickness = 8;
                line.Stroke = System.Windows.Media.Brushes.Red;
                line.X1 = window.Width  / 6;
                line.X2 = window.Width * 5 / 6;
                line.Y1 = window.Height * y1 / 6;
                line.Y2 = window.Height * y2 / 6;
                Grid.SetColumnSpan(line, 3); //Line ist ein Element des Grids, deshalb braucht es Row und Column-Span um komplett sichtbar zu sein
                Grid.SetRowSpan(line, 3);
                Spielfeld.Children.Add(line); //Hinzufügen zum Grid.
            }
            else
            {
                MessageBox.Show("Ungültiger Wert in drawWinningLine");
            }
        }
        //Überladene Metode um vertikale Linien darzustellen
        private void drawWinningLine(int col)
        {
            if (col <= 3 && col > 0) //Hat der Übergabeparameter gültige Werte?
            {
                //Wieder die Sechstelung des X-Wertes
                int x = 1;
                
                if (col == 2)
                    x = 3;
                else if (col == 3)
                    x = 5;
                line = new Line();
                line.StrokeThickness = 8;
                line.Stroke = System.Windows.Media.Brushes.Red;
                line.X1 = window.Width *x/ 6;
                line.X2 = window.Width * x / 6;
                line.Y1 = window.Height  / 6;
                line.Y2 = window.Height * 5 / 6;
                Grid.SetColumnSpan(line, 3);
                Grid.SetRowSpan(line, 3);
                Spielfeld.Children.Add(line);
            }
            else
            {
                MessageBox.Show("Ungültiger Wert in drawWinningLine");
            }
        }
    }
}
