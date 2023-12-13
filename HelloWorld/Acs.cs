using System.Collections.ObjectModel;

namespace HelloWorld
{
    public interface INotifica
    {
        void InviaNotifica();
        string Print();
    }

    public interface ISaluto
    {
        string Saluta(string nome);
    }

    public interface IClock
    {
        DateTime Now { get; }
    }

    public class ClockOrologioSistema: IClock
    {
        public DateTime Now => DateTime.Now;
    }

    public class ClockPerTestAlMattino: IClock
    {
        public DateTime Now => new DateTime(2021, 1, 1, 10, 0, 0);
    }

    public class ClockPerTestAlPomeriggio : IClock
    {
        public DateTime Now => new DateTime(2021, 1, 1, 18, 0, 0);
    }


    public class SalutoSemplice: ISaluto
    {
        private readonly IClock clock;
        private readonly IConfiguration configuration;

        public SalutoSemplice(IClock clock, IConfiguration configuration)
        {
            this.clock = clock;
            this.configuration = configuration;
        }

        public string Saluta(string nome)
        {
            var saluto = configuration["Saluto"];
            if (clock.Now.Hour < 12)
            {
                return $"{saluto}   Buongiorno, {nome}";
            } else
            {
                return $"Buonasera, {nome}";
            }
        }
    }


    public class NotificaWhatsApp: INotifica
    {
        public NotificaWhatsApp()
        {
            
        }

        public void InviaNotifica()
        {
            
        }

        public string Print()
        {
            return "WhatsApp";
        }
    }


    public class NotificaSMS: INotifica
    {
        public NotificaSMS()
        {
            
        }

        public void InviaNotifica()
        {
            
        }

        public string Print()
        {
            return "SMS";
        }
    }


    public class NotificaEMail: INotifica
    {
        // codice .net che manda email
        public NotificaEMail()
        {
            
        }

        public void InviaNotifica()
        {
            
        }

        public string Print()
        {
            return "Email";
        }
    }


    public class  C
    {
        public C(B b)
        {
            
        }
    }

    public class A
    {
        private Random random = new Random();
        private int value;


        

        public A()
        {
        
            value = random.Next(1000);     
        }

        public string PrintA()
        {
            return $"A {value}";
        }
    }

    public class B
    {
        private readonly A a;
        private readonly IEnumerable<INotifica> notifiche;

        public B(A a, IEnumerable<INotifica> notifiche)
        {
            this.a = a;
            this.notifiche = notifiche;
        }

        public string PrintB()
        {
            //  var a = new A();
            // var notifica = new NotificaWhatsApp();

            foreach (var notifica in notifiche)
            {
                notifica.InviaNotifica();
            }

            return a.PrintA() + "B " + notifiche.First().Print();
        }
    }

}

