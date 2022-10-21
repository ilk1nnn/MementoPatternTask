using MementoPatternTask.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MementoPatternTask.DataBase
{
    public static class Database
    {
        public static ImageSource ImageSource { get; set; }
        public static Originator originator = new Originator(ImageSource);
        public static CareTaker careTaker = new CareTaker(originator);
    }
}
