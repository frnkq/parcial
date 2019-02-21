using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entidades;
using Archivos;
using System.Threading;
using Patentes;

namespace _20181122_SP
{
    public partial class FrmPpal : Form
    {
        Queue<Patente> cola;
        List<Thread> hilos;

        public FrmPpal()
        {
            InitializeComponent();

            this.cola = new Queue<Patente>();
            this.hilos = new List<Thread>();
        }

        
        private void FrmPpal_Load(object sender, EventArgs e)
        {
            this.vistaPatente1.finExposicion += ProximaPatente;
            this.vistaPatente2.finExposicion += ProximaPatente;
        }

        private void ProximaPatente(VistaPatente vp)
        {
            if (this.cola.Count > 0)
            {
                Thread h = new Thread(new ParameterizedThreadStart(vp.MostrarPatente));
                this.hilos.Add(h);
                h.Start(this.cola.Dequeue());
            }
                
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            FinalizarSimulacion();
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            Xml xml = new Xml();
            try
            {
                xml.Leer("patentes.xml", out cola);
                this.IniciarSimulacion();
            }catch(Exception ex)
            {

            }

                        
        }

        private void btnTxt_Click(object sender, EventArgs e)
        {
            Texto texto = new Texto();
            try
            {
                texto.Leer("patentes.txt", out cola);
                this.IniciarSimulacion();
            }
            catch(Exception exx)
            {

            }
        }

        private void btnSql_Click(object sender, EventArgs e)
        {
            Sql sql = new Sql();
            try
            {
                sql.Leer("patentes", out cola);
                this.IniciarSimulacion();
            }
            catch(Exception exxx)
            {

            }
        }
        private void IniciarSimulacion()
        {
            FinalizarSimulacion();
            ProximaPatente(this.vistaPatente1);
            ProximaPatente(this.vistaPatente2);
        }
        private void FinalizarSimulacion()
        {
            foreach (Thread t in this.hilos)
                if (t.IsAlive)
                    t.Abort();
        }
    }
}
