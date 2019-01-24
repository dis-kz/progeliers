using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Model;

namespace ServicesLayer
{
    public class DocServices
    {
        static ISynectixDocument docobject;

        //инициализация статического члена класса
        static DocServices()
        {
            docobject = new SynectixDocument();
        }
    }
}
