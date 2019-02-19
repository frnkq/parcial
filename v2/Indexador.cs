    public class Persona
    {
        private string nombre;
        private string nacionalidad;
        private List<string> domicilios;
        private List<string> apodos;

        public string this[int i]
        {
            get
            {
                return apodos[i];
            }
        }

        Persona p = new Persona();
        string apodo = p[3];
    }