using System;
using System.Windows.Forms;

namespace Knight_tour
{

    internal partial class Form1 : Form
    {
        internal const int BoardSize = 5; //5-6-7-8  Ok
        private static int startX, startY, z;
        private static State currnetState;
        private static Agenda agenda;
        private static System.Threading.Thread thread;
        private static System.Drawing.Color red = System.Drawing.Color.Red,
            green = System.Drawing.Color.Green;
        private static System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        internal Form1()
        {
            InitializeComponent();
            for (int i = 0; i < BoardSize; i++)
                for (int j = 0; j < BoardSize; j++)
                    label[i, j].BackColor = red;
            Xtextbox.Text = (BoardSize-1).ToString();
            Ytextbox.Text = (BoardSize-1).ToString();
        }

        private void Start_Click(object sender, EventArgs e)
        {

            char[] d1, d2;
            int q1 = 0, q2 = 0;
            
            z = 0;
            label2.Text = "Loading...";
            System.Threading.Tasks.Task.Delay(1).Wait();
            watch = System.Diagnostics.Stopwatch.StartNew();

            d1 = Xtextbox.Text.ToCharArray();
            d2 = Ytextbox.Text.ToCharArray();
            for (int i = 48; i <= 48 + BoardSize; i++)
            {
                if (d1[0] == i)
                    q1 = 1;
                if (d2[0] == i)
                    q2 = 1;
            }

            if (q1 == 0 && q2 == 0)
                label2.Text = "X && Y are not Ok!";
            else if (q1 == 0)
                label2.Text = "X is not a Ok!";
            else if (q2 == 0)
                label2.Text = "Y is not a Ok!";
            else
            {
                
                startX = int.Parse(Xtextbox.Text);
                startY = int.Parse(Ytextbox.Text);
                bool[,] Cross = new bool[BoardSize, BoardSize];
                for (int i = 0; i < BoardSize; i++)
                    for (int j = 0; j < BoardSize; j++)
                        Cross[j, i] = false;
                
                agenda = new Agenda();
                agenda.Add(".", "S", Cross, startX, startY);
                int x, y;
                while (true)
                {
                    if (!agenda.Remove(ref currnetState)) { label2.Text = "No way to Finish!!!\n" + z + " ways has been checked. in " + watch.ElapsedMilliseconds + "ms"; break; }
                    if (GOAL(currnetState))
                        break;

                    x = currnetState.getX();
                    y = currnetState.getY();
                    Cross = currnetState.getCross();
                    
                    if (x < BoardSize - 2)
                    {
                        if (y > 0)
                            if (!Cross[x + 2, y - 1])
                                agenda.Add("Ru", currnetState.getWay(), Cross, x + 2, y - 1);
                        if (y < BoardSize - 1)
                            if (!Cross[x + 2, y + 1])
                                agenda.Add("Rd", currnetState.getWay(), Cross, x + 2, y + 1);
                    }
                    
                    if (y < BoardSize - 2)
                    {
                        if (x < BoardSize - 1)
                            if (!Cross[x + 1, y + 2])
                                agenda.Add("Dr", currnetState.getWay(), Cross, x + 1, y + 2);
                        if (x > 0)
                            if (!Cross[x - 1, y + 2])
                                agenda.Add("Dl", currnetState.getWay(), Cross, x - 1, y + 2);
                    }
                    
                    if (y > 1)
                    {
                        if (x < BoardSize - 1)
                            if (!Cross[x + 1, y - 2])
                                agenda.Add("Ur", currnetState.getWay(), Cross, x + 1, y - 2);
                        if (x > 0)
                            if (!Cross[x - 1, y - 2])
                                agenda.Add("Ul", currnetState.getWay(), Cross, x - 1, y - 2);
                    }
                    
                    if (x > 1)
                    {
                        if (y > 0)
                            if (!Cross[x - 2, y - 1])
                                agenda.Add("Lu", currnetState.getWay(), Cross, x - 2, y - 1);
                        if (y < BoardSize - 1)
                            if (!Cross[x - 2, y + 1])
                                agenda.Add("Ld", currnetState.getWay(), Cross, x - 2, y + 1);
                    }
                    z++;
                }
                _Show();
            }
        }

        private void _Show()
        {
            bool[,] g = currnetState.getCross();
            for (int i = 0; i < BoardSize; i++)
                for (int j = 0; j < BoardSize; j++)
                    label[j, i].BackColor = (g[j, i]) ? green : red;

            label5.Text = currnetState.getWay();

        }

        private bool GOAL(State currnetState)
        {
            
            if (watch.ElapsedMilliseconds >= 30000)
            {
                label2.Text = "Time out!!!\n" + z + " ways has been checked. in " + watch.ElapsedMilliseconds + "ms";
                return true;
            }

            if (currnetState.getWay().Length < (BoardSize * BoardSize * 2))
                return false;

            bool[,] cross = currnetState.getCross();
            for (int i = 0; i < BoardSize; i++)
                for (int j = 0; j < BoardSize; j++)
                    if (!cross[j, i])
                        return false;
            _Show();
            watch.Stop();
            label2.Text = "Ok\n" + z + " ways has been checked. in " + watch.ElapsedMilliseconds + "ms";

            thread = new System.Threading.Thread(new System.Threading.ThreadStart(__Show));
            thread.Start();
            return true;
        }

        private void __Show()
        {
            char[] a = currnetState.getWay().ToCharArray();
            int x = startX, y = startY;
            System.Drawing.Color C = new System.Drawing.Color();
            for (int i = 0; i < a.Length; i++)
            {


                if (char.IsUpper(a[i]))
                {
                    C = System.Drawing.Color.FromArgb((255 * i) / a.Length, (255 * i) / a.Length, (255 * i) / a.Length);
                    label[x, y].BackColor = C;
                }


                switch (a[i])
                {
                    case 'r': x++; break;
                    case 'd': y++; break;
                    case 'l': x--; break;
                    case 'u': y--; break;
                    case 'R': x += 2; break;
                    case 'D': y += 2; break;
                    case 'L': x -= 2; break;
                    case 'U': y -= 2; break;
                    default: break;
                }
                System.Threading.Tasks.Task.Delay(300).Wait();
            }
            label[x, y].BackColor = C;
        }


        private void Clear_Click(object sender, EventArgs e)
        {
            if (thread != null)
                if (thread.ThreadState != System.Threading.ThreadState.Stopped)
                    thread.Suspend();

            for (int i = 0; i < BoardSize; i++)
                for (int j = 0; j < BoardSize; j++)
                    label[i, j].BackColor = red;

            label2.Text = "Ok";
            label5.Text = "way: ";
            Xtextbox.Text = "0";
            Ytextbox.Text = "0";
        }




    }

    internal class State
    {
        internal State next;
        private string name;
        private const int length = Form1.BoardSize;
        private string way;
        private int x, y;
        private bool[,] Cross;

        internal State(string name, string way, bool[,] Cross, int x, int y)
        {
            this.Cross = new bool[length, length];
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    this.Cross[j, i] = Cross[j, i];

            this.Cross[x, y] = true;
            this.name = name;
            this.way = way + name;
            this.x = x;
            this.y = y;
        }


        internal string getWay()
        {
            return way;
        }
        internal int getX()
        {
            return x;
        }
        internal int getY()
        {
            return y;
        }
        internal bool[,] getCross()
        {
            return this.Cross;
        }
    }

    internal class Agenda
    {
        private State front;

        /*
         internal bool Add(string name, string way, bool[,] Cross, int x, int y)
         {
             State s = new State(name, way, Cross, x, y);
             if (rear == null)
                 front = rear = s;
             rear.next = s;
             rear = s;
             return true;
        }*/
        
        internal bool Add(string name, string way, bool[,] Cross, int x, int y)
        {
            State s = new State(name, way, Cross, x, y);
            if (front == null)
            {
                front = s;
                return true;
            }

            s.next = front;
            front = s;
            return true;
        }

        internal bool Remove(ref State item)
        {
            if (front == null) return false;
            item = front;
            front = front.next;
            return true;
        }
    }
}
