using System.Collections.Generic;
using System.Linq;
using m = CapacityPlan.Modelo;
namespace CapacityPlan.Reporting.Resumen
{
    public class Datos
    {
        private static short Mes;
        private static short Year;

        public static Equipo[] getEquipos(m.Tarea[] tareas, short mes, short year)
        {
            Mes = mes;
            Year = year;

            List<Equipo> equipos = new List<Equipo>();

            foreach (var tareasPorEquipo in tareas.GroupBy(_ => _.Equipo))
            {
                Equipo equipo = new Equipo(tareasPorEquipo.Key.Nombre);
                setEquipo(equipo, tareasPorEquipo);
                equipos.Add(equipo);
            }

            return equipos.ToArray();
        }

        private static void setEquipo(Equipo equipo, IEnumerable<m.Tarea> tareas)
        {
            foreach (var tareasPorServicio in tareas.GroupBy(_ => _.Servicio))
            {
                Servicio servicio = new Servicio(tareasPorServicio.Key.Nombre);

                setServicio(servicio, tareasPorServicio);

                equipo.Servicios.Add(servicio);
            }
        }

        private static void setServicio(Servicio servicio, IEnumerable<m.Tarea> tareas)
        {
            foreach (var tareasPorTipo in tareas.GroupBy(_ => _.TipoDeTarea))
            {
                if (tareasPorTipo.Key.Id == Helpers.TipoDeTarea.INTERNAL_PRODUCTIVITY)
                    setValoresProduccion(servicio, tareasPorTipo);

                if (tareasPorTipo.Key.Id == Helpers.TipoDeTarea.CONTROL_MANAGEMENT)
                    setValoresGestionControl(servicio, tareasPorTipo);
            }
        }

        private static void setValoresProduccion(Servicio servicio, IEnumerable<m.Tarea> tareas)
        {
            servicio.KPI_Produccion = 0;
            servicio.FTE_Produccion = 0;

            foreach (m.Tarea tarea in tareas)
            {
                m.Rendimiento rendimiento = tarea.Rendimientos.Where(_ => _.Mes == Mes && _.Year == Year).FirstOrDefault();

                if (rendimiento != null)
                {
                    servicio.KPI_Produccion += rendimiento.KPI ?? 0;
                    servicio.FTE_Produccion += rendimiento.FTE ?? 0;
                }
            }
        }

        private static void setValoresGestionControl(Servicio servicio, IEnumerable<m.Tarea> tareas)
        {
            servicio.KPI_GestionCtr = 0;
            servicio.FTE_GestionCtr = 0;

            foreach (m.Tarea tarea in tareas)
            {
                m.Rendimiento rendimiento = tarea.Rendimientos.Where(_ => _.Mes == Mes && _.Year == Year).FirstOrDefault();

                if (rendimiento != null)
                {
                    servicio.KPI_GestionCtr += rendimiento.KPI ?? 0;
                    servicio.FTE_GestionCtr += rendimiento.FTE ?? 0;
                }
            }
        }

    }
}
