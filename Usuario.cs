namespace CapacityPlan.Modelo
{
    public class Usuario : Elemento
    {
        public string UserName { get; set; }
        public string Hash { get; set; }
        public bool ClaveTemporal { get; set; } = false;

        public Equipo Equipo { get; set; }
        public Permisos Permisos { get; set; }

        public Usuario() : base() { inicializacion(); }
        public Usuario(int Id) : base(Id) { inicializacion(); }

        private void inicializacion()
        {
            Permisos = new Permisos();

            if (Id == 0)
            {
                Permisos.Administracion = true;
                Permisos.Configuracion = true;
                Permisos.IntroduccionDeDatos = true;
                Permisos.Reporting = true;
            }
        }
    }
}
