using System;

namespace CapacityPlan.Modelo
{
    public abstract class Elemento
    {
        public int Id
        {
            get => id;
        }
        private int id;
        public string Nombre { get; set; }

        public Elemento(int Id)
            => this.id = Id;

        public Elemento()
            => this.id = -1;

        public void SetId(int id)
        {
            if (Id != -1) throw new Exception();
            this.id = id;
        }

        public override string ToString() => Nombre;
    }

}
