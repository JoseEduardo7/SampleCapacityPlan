using System;

namespace CapacityPlan.Modelo
{
    public class HeadCount : Elemento
    {
        public Equipo Equipo { get; set; }
        public Servicio Servicio { get; set; }
        public double FTE { get; set; }
        public string UsuarioHost { get; set; }
        public string HR_ID { get; set; }
        public string CorporateTitle { get; set; }
        public string Email { get; set; }
        public CentroCoste CentroDeCoste { get; set; }
        public TipoEmpleado TipoDeEmpleado { get; set; }
        public Convenio Convenio { get; set; }
        public DateTime FinContrato { get; set; }

        public HeadCount() : base() { inicializacion(); }
        public HeadCount(int Id) : base(Id) { inicializacion(); }

        private void inicializacion()
        {
            FinContrato = DateTime.Now;
        }
    }
}
